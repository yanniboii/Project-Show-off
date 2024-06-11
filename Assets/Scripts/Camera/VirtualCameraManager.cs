using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera copyCam;
    [SerializeField] List<CinemachineVirtualCamera> pasteCams = new List<CinemachineVirtualCamera>();
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            for (int i = 0; i < pasteCams.Count; i++)
            {
                Debug.Log("Upd");   
                pasteCams[i].m_Lens = copyCam.m_Lens;
                pasteCams[i].m_Transitions = copyCam.m_Transitions;
                pasteCams[i].GetCinemachineComponent(CinemachineCore.Stage.Body).Equals(copyCam.GetCinemachineComponent(CinemachineCore.Stage.Body));
                pasteCams[i].GetCinemachineComponent(CinemachineCore.Stage.Aim).Equals(copyCam.GetCinemachineComponent(CinemachineCore.Stage.Aim));

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
