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
    }
}
