using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;

    //Movement Settings

    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float gravity;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float turnSmoothVelocity; //variables to smooth turning the character
    [SerializeField] private float turnSmoothTime;

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

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        speed = 6.0f;
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


        //JumpCheck(direction); //direction = JumpCheck(direction);

        //velocity.y -= gravity + Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); // only Y axis for jump functionality

        if (controller.isGrounded) //&& velocity.y < 0
        {
            velocity.y = -2f;
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
        anim.SetBool("Trigger", true);
        yield return new WaitForSeconds(5.0f);
        anim.SetBool("Trigger", false);
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
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * (Vector3.forward); //face direction based on camera

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

            //anim.SetFloat("Velocity", speed, turnSmoothTime, Time.deltaTime);

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
