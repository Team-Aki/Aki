using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent puppy;
    Vector3 conversion;

    // Start is called before the first frame update
    void Start()
    {
        //conversion = player.TransformPoint(player.parent.position);
    }

    // Update is called once per frame
    void Update()
    {
        puppy.SetDestination(player.position);
    }
}
