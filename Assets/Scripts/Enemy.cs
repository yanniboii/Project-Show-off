using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region vars

    [SerializeField] NavMeshAgent agent;

    private GameObject target;

    #endregion

    #region unity functions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region private functions
    void FindTarget()
    {
        float previousClosest = Mathf.Infinity;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20, 10);
        foreach (Collider collider in colliders)
        {
            previousClosest = Mathf.Min(previousClosest, Vector3.Distance(transform.position, collider.transform.position));
        }
    }
    #endregion
}
