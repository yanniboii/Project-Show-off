using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] MonsterData monsterData;
    [SerializeField] Vector3 dir;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }
    
    void GetInput()
    {
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * monsterData.speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * monsterData.speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * monsterData.speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * monsterData.speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * monsterData.jumpHeight;
        }
    }
}
