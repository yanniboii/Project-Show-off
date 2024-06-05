using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera copyCam;
    [SerializeField] List<CinemachineVirtualCamera> pasteCams = new List<CinemachineVirtualCamera>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < pasteCams.Count; i++)
        {
            pasteCams[i] = copyCam;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
