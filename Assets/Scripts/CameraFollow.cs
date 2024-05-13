using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public GameObject myCamera;
    Vector3 origin;
    public void SelectCamera()
    {
        myCamera = GameObject.Find("Camera1");
        origin = this.transform.position;
        Debug.Log(myCamera);
    }
}
