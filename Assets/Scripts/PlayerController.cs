using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private Animator anim;

    //Movement Settings

    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float gravity;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float turnSmoothVelocity; //variables to smooth turning the character
    [SerializeField] private float turnSmoothTime;

    RaycastHit hit;//For Detect Sureface/Base.
    Vector3 surfaceNormal;//The normal of the surface the ray hit.
    Vector3 forwardRelativeToSurfaceNormal;//For Look Rotation
    Quaternion targetRotation;
    //public LayerMask mask;

    /*  [SerializeField] private float jumpHeight;
      [SerializeField] private float doubleJumpMultiplier;
      private bool doubleJump = false;
      private bool isJumping = false;
      private bool isSprinting = false;*/

    /*    //Acceleration settings
        [SerializeField] private float maxSpeed;
        [SerializeField] private float timeZeroToMax;
        [SerializeField] private float accelRatePerSec; //difference in velocity per sec
        [SerializeField] private float forwardVelocity; //*/

    private float directionY; //temp value for direction

    private float joyHorizontal;
    private float joyVertical;
    Vector2 joyInput;
    float horizontal, vertical;
    Vector2 keyboardInput;
    private int XboxController = 0;
    private int Ps4Controller = 0;
    private bool isUsingController;
    private bool isUsingKeyboard;
    private bool stopMovement = false;
    /*    private bool alignToGround = true;
        Vector3 vAlignToGround;*/

   /* public Transform backLeft;
    public Transform backRight;
    public Transform frontLeft;
    public Transform frontRight;
    public RaycastHit lr;
    public RaycastHit rr;
    public RaycastHit lf;
    public RaycastHit rf;*/

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        speed = 7.5f;
        sprintMultiplier = 2.0f;
        gravity = 19.81f;
        turnSmoothTime = 0.1f;
/*        jumpHeight = 14.0f;
        doubleJumpMultiplier = 1.0f;*/
        sprint = speed * sprintMultiplier;
        CheckController();



        /*        maxSpeed = 10.0f;
                timeZeroToMax = 5.8f;
                accelRatePerSec = maxSpeed / timeZeroToMax; //equation of acceleration
                forwardVelocity = 0.0f;*/
    }

    // Update is called once per frame
    void Update()
    {
        RotateToSurface();

        keyboardInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        joyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //sphere at bottom of the player to check for collisions for gravity checks

        if (isUsingController)
        {
            JoypadInput();
            Vector3 joyDirection = new Vector3(joyInput.x, 0.0f, joyInput.y).normalized; //normalize to not double the speed when pressing 2 or more keys
            MoveCharacter(joyDirection);
        }
        else
        {

            KeyboardInput();
            Vector3 direction = new Vector3(keyboardInput.x, 0.0f, keyboardInput.y).normalized; //normalize to not double the speed when pressing 2 or more keys
            MoveCharacter(direction);
        }

        UpdateGravity();

        if (stopMovement)
        {
            //CharacterController cc = GetComponent<CharacterController>();
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            StartCoroutine(StopMovement());
            stopMovement = false;
        }


        //JumpCheck(direction); //direction = JumpCheck(direction);

        //velocity.y -= gravity + Time.deltaTime;



        controller.Move(velocity * Time.deltaTime); // only Y axis for jump functionality

        if (controller.isGrounded) //&& velocity.y < 0
        {
            velocity.y = -2f;
        }

    }
    private void RotateToSurface()
    {
        //For Detect The Base/Surface.
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
        {
            surfaceNormal = hit.normal; // Assign the normal of the surface to surfaceNormal
            forwardRelativeToSurfaceNormal = Vector3.Cross(transform.right, surfaceNormal);
            targetRotation = Quaternion.LookRotation(forwardRelativeToSurfaceNormal, surfaceNormal); //check For target Rotation.
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 3); //Rotate Character 
            // it seems to reset the rotation position when I move the character, might bbe

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cutscene"))
        {
            StartCoroutine(InteractionAnimation());
        }
    }

    private IEnumerator InteractionAnimation()
    {
        stopMovement = true;
        anim.SetBool("Trigger", true);
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("Trigger", false);

    }

    private IEnumerator StopMovement()
    {
        controller.enabled = false;
        yield return new WaitForSeconds(11.0f);
        controller.enabled = true;
    }

    private bool JoypadInput()
    {
        isUsingController = true;
        joyHorizontal = Input.GetAxis("Horizontal");
        joyVertical = Input.GetAxis("Vertical");
        return isUsingController;
    }

    private bool KeyboardInput()
    {
        isUsingKeyboard = true;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        return isUsingKeyboard;
    }

    private void CheckController()
    {
        string[] names = Input.GetJoystickNames();

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Length == 19)
            {
                print("Ps4 Controller connected");
                Ps4Controller = 1;
                XboxController = 0;
                isUsingController = true;
            }

            if (names[i].Length == 33)
            {
                print("Xbox Controller connected");
                XboxController = 1;
                Ps4Controller = 0;
                isUsingController = true;
            }
        }
    }

    private void MoveCharacter(Vector3 direction)
    {
        if (direction.magnitude >= 0.1) //get input to move
        {
            // Atan2 -> returns angle between x-axis and vector starting at 0 to x,y
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //face direction the player is moving
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //function to smooth the angle turn
            float angleX = transform.eulerAngles.x; //function to smooth the angle turn

/*            if (angleX >= 45)
                angleX = 0;
*/
            transform.rotation = Quaternion.Euler(angleX, angle, 0f); //this could be the cause for the character resetting the rotation when moving
            //probably overriding the rotation, don't know how to solve


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * (Vector3.forward); //face direction based on camera

            //RotateToSurface();

            //JumpCheck(moveDir);

            /*forwardVelocity += accelRatePerSec;
            speed += forwardVelocity;
            speed = Mathf.Min(forwardVelocity, maxSpeed);*/

            if (isUsingController)
            {
                if (joyHorizontal > 0.5f || joyHorizontal < -0.5f)
                {
                    controller.Move(moveDir.normalized * sprint * Time.deltaTime);
                    //anim.SetFloat("Velocity", sprint, turnSmoothTime, Time.deltaTime);
                }
                else if (joyVertical > 0.5f || joyVertical < -0.5f)
                {
                    controller.Move(moveDir.normalized * sprint * Time.deltaTime);
                    //anim.SetFloat("Velocity", sprint, turnSmoothTime, Time.deltaTime);
                }
                else
                {
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    //anim.SetFloat("Velocity", speed, turnSmoothTime, Time.deltaTime);
                }
            }
            else
            {
                if (Input.GetButton("Sprint")) //on hold
                {
                    controller.Move(moveDir.normalized * sprint * Time.deltaTime);
                    //anim.SetFloat("Velocity", sprint, turnSmoothTime, Time.deltaTime);
                }
                else
                {
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    //anim.SetFloat("Velocity", speed, turnSmoothTime, Time.deltaTime);

                }
            }

        }

        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        Vector3 velocity = controller.velocity;
        Vector3 localVelocity = controller.transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z; //take forward velocity as it's the one we need
        anim.SetFloat("Velocity", speed);
    }

    private void UpdateGravity()
    {
        directionY -= gravity * Time.deltaTime;
        velocity.y = directionY;
    }

   /* private Vector3 JumpCheck(Vector3 direction)
    {
        if (controller.isGrounded)
        {
            isJumping = false;

            if (Input.GetButtonDown("Jump"))
            {
                doubleJump = true;
                //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //better check to force player on the ground - eh no
                directionY = jumpHeight;
                isJumping = true;
            }
            if (Input.GetButtonDown("Jump") && direction.magnitude >= 0.1)
            {
                doubleJump = true;
                directionY = jumpHeight;
                isJumping = true;
            }


        }
        else if(Input.GetButtonDown("Jump") && doubleJump)
        {
            directionY = jumpHeight * doubleJumpMultiplier;
            doubleJump = false;
            isJumping = true;
        }

        return direction;
    }*/
}
