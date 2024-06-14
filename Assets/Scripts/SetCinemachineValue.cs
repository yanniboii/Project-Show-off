using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCinemachineValue : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetRotationSpeed(float speed)
    {
        Debug.Log("A");
        Debug.Log(virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>());
        if (virtualCamera != null && virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>() != null)
        {
            Debug.Log(speed);
            virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_InputAxisValue = speed;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
