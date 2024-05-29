using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] BasicMovement basicMovement;
    [SerializeField] InactiveMovement inactiveMovement;
    [SerializeField] Ability ability;
    [SerializeField] NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public BasicMovement GetBasicMovement()
    {
        return basicMovement;
    }

    public InactiveMovement GetInactiveMovement()
    {
        return inactiveMovement;
    }
    
    public Ability GetAbility()
    {
        return ability;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }
}
