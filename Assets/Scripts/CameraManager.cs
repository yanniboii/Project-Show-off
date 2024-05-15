using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    [SerializeField] Camera camera3;
    [SerializeField] Camera camera4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void AddCameraToPlayer(PlayerInput playerInput)
    {
        CameraMover cameraMover = playerInput.gameObject.GetComponent<CameraMover>();
        int pi = playerInput.playerIndex;
        if(pi == 0)
        {
            cameraMover.cam = camera1;
            cameraMover.brain = CinemachineCore.Instance.GetActiveBrain(0);
            playerInput.camera = camera1;
        }
        if(pi == 1)
        {
            cameraMover.cam = camera2;
            cameraMover.brain = CinemachineCore.Instance.GetActiveBrain(1);
            playerInput.camera = camera2;
        }
        if( pi == 2)
        {
            cameraMover.cam = camera3;
            cameraMover.brain = CinemachineCore.Instance.GetActiveBrain(2);
            playerInput.camera = camera3;
        }
        if(pi == 3)
        {
            cameraMover.cam = camera4;
            cameraMover.brain = CinemachineCore.Instance.GetActiveBrain(3);
            playerInput.camera = camera4;
        }
    }
}
