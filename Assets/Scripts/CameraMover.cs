using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Tooltip("the camera that will be dissabled or enabled")]
    [SerializeField] int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraInfo cam = other.gameObject.GetComponent<BasicMovement>().cameraInfo;
            if (index >= cam.virtualCameras.Count) return;
            GameObject camGO = cam.virtualCameras[index].gameObject;
            if (camGO.active)
            {
                camGO.SetActive(false);
                cam.virtualCameraIndex++;
            }
            else
            {
                camGO.SetActive(true);
                cam.virtualCameraIndex--;
            }
        }
    }

}
