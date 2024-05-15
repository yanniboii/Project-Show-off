using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    [SerializeField] Camera camera3;
    [SerializeField] Camera camera4;

    // Start is called before the first frame update
    void Awake()
    {
        OnePlayerCamera();
    }

    public void OnePlayerCamera()
    {
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera1.rect = new Rect(0,0,1,1);
    }
    public void TwoPlayerCamera()
    {
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(false);
        camera4.gameObject.SetActive(false);
        camera1.rect = new Rect(0.25f, 0, 0.5f, 0.5f);
        camera2.rect = new Rect(0.25f, 0.5f, 0.5f, 0.5f);
    }
    public void ThirdPlayerCamera()
    {
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(true);
        camera4.gameObject.SetActive(false);
        camera1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        camera2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        camera3.rect = new Rect(0.25f, 0, 0.5f, 0.5f);
    }
    public void FourPlayerCamera()
    {
        camera2.gameObject.SetActive(true);
        camera3.gameObject.SetActive(true);
        camera4.gameObject.SetActive(true);
        camera1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        camera2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        camera3.rect = new Rect(0, 0, 0.5f, 0.5f);
        camera4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
    }
}
