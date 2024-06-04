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
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, LayerMask.NameToLayer("Player"));
        
        Vector3 dest = Vector3.zero;
        Debug.Log(colliders.Length + " : "+ LayerMask.NameToLayer("Player"));
        foreach (Collider collider in colliders)
        {
            previousClosest = Mathf.Min(previousClosest, Vector3.Distance(transform.position, collider.transform.position));

            Debug.Log(Vector3.Distance(transform.position, collider.transform.position));

            if (previousClosest == Vector3.Distance(transform.position, collider.transform.position))
            {
                target = collider.gameObject;
                dest = collider.transform.position;
                Debug.Log("SA");
            }
        }
        agent.destination = dest;
        Debug.Log("WA "+dest + " : "+previousClosest);
    }
    #endregion
}
