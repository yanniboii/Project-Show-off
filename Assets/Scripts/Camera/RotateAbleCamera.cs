using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbleCamera : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    bool noPlayer = true;
    Vector2 rotation = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (noPlayer)
            {
                player.beforeRotate += OnCameraRotated;
                noPlayer = false;
            }
            //transform.RotateAround(transform.parent.position, Vector3.up, rotation.x);
            ////transform.RotateAround(transform.parent.position, transform.local, rotation.y);
            //Vector3 dir = (transform.position - transform.parent.position).normalized;
            //transform.position = transform.parent.position + dir * distToPlayer;
            if(rotation.x != 0)
            {
                Quaternion rotx = Quaternion.AngleAxis(-rotation.x * speed * Time.deltaTime, Vector3.up);
                offset = rotx * offset;
            }

            if (rotation.y != 0)
            {
                Vector3 rightAxis = Vector3.Cross(Vector3.up, offset).normalized;
                Quaternion roty = Quaternion.AngleAxis(-rotation.y * speed * Time.deltaTime, rightAxis);
                offset = roty * offset;
            }




            transform.position = transform.parent.position + offset;
            transform.LookAt(transform.parent.position);
        }
    }

    void OnCameraRotated(Vector2 vector2)
    {
        rotation = vector2;

    }
}
