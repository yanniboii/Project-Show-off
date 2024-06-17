using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    [SerializeField] CameraInfo camera1;
    [SerializeField] CameraInfo camera2;
    [SerializeField] CameraInfo camera3;
    [SerializeField] CameraInfo camera4;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraPriority(camera1);
        SetCameraPriority(camera2);
        SetCameraPriority(camera3);
        SetCameraPriority(camera4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnePlayerCamera()
    {
        camera2.camera.gameObject.SetActive(false);
        camera3.camera.gameObject.SetActive(false);
        camera4.camera.gameObject.SetActive(false);

        camera1.camera.rect = new Rect(0,0,1,1);
    }
    public void TwoPlayerCamera()
    {
        camera2.camera.gameObject.SetActive(true);
        camera3.camera.gameObject.SetActive(false);
        camera4.camera.gameObject.SetActive(false);

        camera1.camera.rect = new Rect(0.25f, 0, 0.5f, 0.5f);
        camera2.camera.rect = new Rect(0.25f, 0.5f, 0.5f, 0.5f);
    }
    public void ThirdPlayerCamera()
    {
        camera2.camera.gameObject.SetActive(true);
        camera3.camera.gameObject.SetActive(true);
        camera4.camera.gameObject.SetActive(false);

        camera1.camera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        camera2.camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        camera3.camera.rect = new Rect(0.25f, 0, 0.5f, 0.5f);
    }
    public void FourPlayerCamera()
    {
        camera2.camera.gameObject.SetActive(true);
        camera3.camera.gameObject.SetActive(true);
        camera4.camera.gameObject.SetActive(true);

        camera1.camera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        camera2.camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        camera3.camera.rect = new Rect(0, 0, 0.5f, 0.5f);
        camera4.camera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
    }

    public CameraInfo GetCameraInfo(int index)
    {
        switch (index)
        {
            case 0:
                return camera1;

            case 1:
                return camera2;
            case 2:
                return camera3;
            case 3:
                return camera4;
        }
        return camera1;
    }

    public void AddCameraToPlayer(PlayerInput playerInput)
    {
        Player player = playerInput.gameObject.GetComponent<Player>();
        BasicMovement basicMovement = player.followObject.GetComponent<BasicMovement>();
        int pi = playerInput.playerIndex;
        if(pi == 0)
        {
            camera1.SetFollowObj(playerInput.gameObject.transform);
            player.cameraInfo = camera1;
            playerInput.camera = camera1.camera;
            basicMovement.cameraInfo = camera1;
        }
        if(pi == 1)
        {
            camera2.SetFollowObj(playerInput.gameObject.transform);
            player.cameraInfo = camera2;
            playerInput.camera = camera2.camera;
            basicMovement.cameraInfo = camera2;
        }
        if ( pi == 2)
        {

            camera3.SetFollowObj(playerInput.gameObject.transform);
            player.cameraInfo = camera3;
            playerInput.camera = camera3.camera;
            basicMovement.cameraInfo = camera3;
        }
        if (pi == 3)
        {
            camera4.SetFollowObj(playerInput.gameObject.transform);
            player.cameraInfo = camera4;
            playerInput.camera = camera4.camera;
            basicMovement.cameraInfo = camera4;
        }
    }
    void SetCameraPriority(CameraInfo cameraInfo)
    {
        for (int i = 0; i < cameraInfo.virtualCameras.Count; i++)
        {
            cameraInfo.virtualCameras[i].Priority = 100 - i;
        }
    }
}

[System.Serializable]
public struct CameraInfo
{
    public Camera camera;
    public CinemachineBrain brain;
    public int virtualCameraIndex;
    public List<CinemachineVirtualCamera> virtualCameras;

    public void SetFollowObj(Transform transform)
    {
        for(int i = 0; i < virtualCameras.Count; i++)
        {
            virtualCameras[i].LookAt = transform;
            virtualCameras[i].Follow = transform;
            if (virtualCameras[i].gameObject.GetComponent<RotateAbleCamera>() != null)
            {
                virtualCameras[i].gameObject.GetComponent<RotateAbleCamera>().player = transform.GetComponent<Player>();
            }
        }
    }
}

