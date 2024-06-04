using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class hoveringAnimation : MonoBehaviour
{

    [SerializeField] Transform Rotateobject;

    [SerializeField] float rotatespeed;
    [SerializeField] float rotatespeed2;

    [SerializeField] float bobamount;

    float starty;
    // Start is called before the first frame update
    void Start()
    {
        starty = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,starty + bobamount * Mathf.Sin(Time.realtimeSinceStartup),transform.position.z);
        Vector3 preveuler = Rotateobject.rotation.eulerAngles;
        Quaternion quaternion = Quaternion.Euler(0f, preveuler.y +rotatespeed * Time.deltaTime, preveuler.z + rotatespeed2 * Time.deltaTime);
        Rotateobject.rotation = quaternion;
    }
}
