using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeView : MonoBehaviour
{
    public GameObject cameraLocation;
    public string playerCamera;
    GameObject myCamera;
    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myCamera = GameObject.Find(playerCamera.ToString());
            myCamera.transform.position = cameraLocation.transform.position;
            myCamera.transform.rotation = cameraLocation.transform.rotation;
        }
    }*/
}
