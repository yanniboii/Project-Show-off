using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Camera cam;
    Transform start;
    Transform end;

    private void Start()
    {
        end = cam.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraCollider"))
        {
            start = other.transform.GetChild(0).transform;

            moveCam(other);
            cam.transform.rotation = other.transform.GetChild(0).transform.rotation;
        }
    }
    void moveCam(Collider other)
    {
        while(cam.transform.position != other.transform.GetChild(0).transform.position)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, other.transform.GetChild(0).transform.position, 0.2f);
        }
    }
}
