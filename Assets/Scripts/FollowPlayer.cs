using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent puppy;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        puppy.SetDestination(player.position);
        UpdateMovementAnimation();

    }

    private void UpdateMovementAnimation()
    {
        Vector3 velocity = puppy.velocity;
        Vector3 localVelocity = puppy.transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z; //take forward velocity as it's the one we need
        anim.SetFloat("Velocity", speed);
    }
}
