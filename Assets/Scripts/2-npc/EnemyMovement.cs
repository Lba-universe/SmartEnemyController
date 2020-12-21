using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// This component represents an enemy movement to given target
// using NavMeshAgent.

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{

    public Transform target = null;

    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private float MovementSpeed = 10f;

    [SerializeField]
    private float rotationSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (navMeshAgent.hasPath)
            {
                navMeshAgent.speed = MovementSpeed;
                FaceDestination();
            }
        }
    }
    private void FaceDestination()
    {
        Vector3 directionToDestination = (navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToDestination.x, 0, directionToDestination.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Gradual rotation
    }
}
