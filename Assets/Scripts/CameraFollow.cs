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

    private void Update()
    {
        if (this.transform.position.x > origin.x + 7f)
        {
            float i = 0;
            i += 0.01f;
            myCamera.transform.position = new Vector3(Mathf.Lerp(myCamera.transform.position.x, this.transform.position.x, i), myCamera.transform.position.y, myCamera.transform.position.z);
        }
        if (this.transform.position.y > origin.y + 8)
        {
            float i = 0;
            i += 0.01f;
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, Mathf.Lerp(myCamera.transform.position.y, this.transform.position.y, i), myCamera.transform.position.z);
        }
        else
        {
            float i = 0;
            i += 0.01f;
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, Mathf.Lerp(myCamera.transform.position.y, 7.8f, i), myCamera.transform.position.z);
        }
    }
}
