using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region vars

    [SerializeField] NavMeshAgent agent;
    [SerializeField] float detectionRange;

    [SerializeField] GameObject target;

    #endregion

    #region unity functions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }
    #endregion

    #region private functions
    void FindTarget()
    {
        float previousClosest = Mathf.Infinity;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, LayerMask.GetMask("Player"));
        
        Vector3 dest = Vector3.zero;
        
        foreach (Collider collider in colliders)
        {
            float dist = Vector3.Distance(transform.position, collider.transform.position);
            previousClosest = Mathf.Min(previousClosest, dist);

            if (previousClosest == dist)
            {
                target = collider.gameObject;
                dest = collider.transform.position;
            }
        }
        agent.destination = dest;
    }
    #endregion
}
