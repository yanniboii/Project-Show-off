using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToRotatorPos : MonoBehaviour
{
    public Transform target;
    [SerializeField] float lerpValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //transform.position = Vector3.Lerp(transform.position,target.position, lerpValue);
            //transform.rotation = Quaternion.Lerp(transform.rotation,target.rotation, lerpValue);
            transform.position = target.position;
            transform.rotation = target.rotation;
        }

    }
}
