using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent puppy;
    private Animator anim;
    private bool activateAI;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activateAI)
        {
            Debug.Log("AI ACTIVE");
            puppy.SetDestination(player.position);
            UpdateMovementAnimation();
        }
    }

    public void ActivateAI()
    {
        activateAI = true;
    }

    public void DeactivateAI()
    {
        activateAI = false;
    }

    private void UpdateMovementAnimation()
    {
        Vector3 velocity = puppy.velocity;
        Vector3 localVelocity = puppy.transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z; //take forward velocity as it's the one we need
        anim.SetFloat("Velocity", speed);
    }
}
