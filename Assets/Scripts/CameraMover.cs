using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Camera cam;
    public CinemachineBrain brain;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraCollider"))
        {
            cam.enabled = false;
            brain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
        }
    }

}
