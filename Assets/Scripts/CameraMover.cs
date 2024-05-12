using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Camera cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraCollider"))
        {
            Vector3 temppos = cam.transform.position;
            Quaternion temprot = cam.transform.rotation;

            cam.transform.position = other.transform.GetChild(0).transform.position;

            cam.transform.rotation = other.transform.GetChild(0).transform.rotation;

            other.transform.GetChild(0).transform.position = temppos;
            other.transform.GetChild(0).transform.rotation = temprot;
        }
    }
}
