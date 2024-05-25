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
        agent.ResetPath();

        Debug.Log("Starting to look ");
        if (players.Count >= 0)
        {
            Vector3 closestPlayer = Vector3.positiveInfinity;
            for (int i = 0; i < players.Count; i++)
            {
                if(Mathf.Min(closestPlayer.magnitude, players[i].transform.position.magnitude) != closestPlayer.magnitude)
                {
                    closestPlayer = players[i].transform.position;
                }
                Debug.Log("Closest player" + closestPlayer);
            }
            if(closestPlayer.magnitude > 7)
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
