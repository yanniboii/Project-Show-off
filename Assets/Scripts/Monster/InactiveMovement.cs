using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InactiveMovement : MonoBehaviour
{
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToClosestPlayer(List<GameObject> players)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        agent.updatePosition = true;
        agent.updateRotation = true;
        if (agent.isOnNavMesh)
        {
            agent.ResetPath();
            if (players.Count > 0)
            {
                float closestPlayer = Mathf.Infinity;
                Vector3 dest = Vector3.zero;
                for (int i = 0; i < players.Count; i++)
                {
                    float dist = Vector3.Distance(transform.position, players[i].transform.position);
                    closestPlayer = Mathf.Min(closestPlayer, dist);
                    if (closestPlayer == dist)
                    {
                        dest = players[i].transform.position;
                    }
                }
                agent.destination = dest;
                destination = dest;
            }
            else
            {
                Debug.Log("empty target");
            }
        }

    }

    public void updatePostion()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = true;
        agent.Warp(transform.position);
        agent.nextPosition = transform.position;
    }
    public void DisableAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent.isOnNavMesh)
        {
            agent.ResetPath();
            agent.isStopped = true;
            agent.updatePosition = false;
            agent.updateRotation = false;
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
    }

}







//Collider[] colliders = Physics.OverlapSphere(transform.position, 20, 10);

//if (colliders.Length > 0)
//{
//    Vector3 closestMonster = Vector3.positiveInfinity;
//    for (int i = 0; i < colliders.Length; i++)
//    {
//        if (Mathf.Min(closestMonster.magnitude, colliders[i].transform.position.magnitude) != closestMonster.magnitude)
//        {
//            closestMonster = colliders[i].transform.position;
//        }
//        Vector3 reverseDir = new Vector3(-closestMonster.x, closestMonster.y, -closestMonster.z);
//        agent.destination = reverseDir;
//        destination = reverseDir;
//    }
//}