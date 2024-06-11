using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBall : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnBall()
    {
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.freezeRotation = false;
        rb.velocity = Vector3.zero;
    }
}
