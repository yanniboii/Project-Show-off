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
        if (agent.isOnNavMesh)
        {
            agent.ResetPath();
            if (players.Count > 0)
            {
                Vector3 closestPlayer = Vector3.positiveInfinity;
                for (int i = 0; i < players.Count; i++)
                {
                    if (Mathf.Min(closestPlayer.magnitude, players[i].transform.position.magnitude) != closestPlayer.magnitude)
                    {
                        closestPlayer = players[i].transform.position;
                    }
                }
                if (closestPlayer.magnitude > 7)
                {
                    agent.destination = closestPlayer;
                    destination = closestPlayer;
                }
            }
            else
            {
                Debug.Log("empty target");
            }
        }

    }
    public void DisableAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if(agent.isOnNavMesh)
        {
            agent.ResetPath();
            agent.isStopped = true;
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