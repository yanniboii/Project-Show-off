using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbleCamera : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] float distToPlayer;
    bool noPlayer = true;
    Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(noPlayer)
            {
                player.beforeRotate += OnCameraRotated;
                noPlayer = false;         
            }
            transform.RotateAround(player.transform.position, Vector3.up, rotation.x);
            transform.RotateAround(player.transform.position, Vector3.right, rotation.y);
            Vector3 dir = (transform.position - player.transform.position).normalized;
            transform.position = player.transform.position + dir * distToPlayer;
        }

    }

    void OnCameraRotated(Vector2 vector2)
    {
        rotation = vector2;

    }
}
