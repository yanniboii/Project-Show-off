using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InactiveMovement : MonoBehaviour
{
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
        if (players.Count <= 0)
        {
            Vector3 closestPlayer = Vector3.positiveInfinity;
            for (int i = 0; i < players.Count; i++)
            {
                closestPlayer = Vector3.Min(closestPlayer, players[i].transform.position);
            }
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = closestPlayer;
        }
    }
}
