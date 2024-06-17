using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Tooltip("the camera that will be dissabled or enabled")]
    [SerializeField] int index;
    [SerializeField] bool enable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BasicMovement basicMovement = other.gameObject.GetComponent<BasicMovement>();
            //if (basicMovement.player == null) { return; }
            CameraInfo cam = basicMovement.cameraInfo;

            Debug.Log(cam.virtualCameras.Count);
            if (index >= cam.virtualCameras.Count) return;
            GameObject camGO = cam.virtualCameras[index].gameObject;
            if (enable)
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
