using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class VirtualCameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera copyCam;
    [SerializeField] List<CinemachineVirtualCamera> pasteCams = new List<CinemachineVirtualCamera>();
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void UpdateValues()
    {
        for (int i = 0; i < pasteCams.Count; i++)
        {
            CopyProperties(pasteCams[i]);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

    void CopyProperties(CinemachineVirtualCamera pasteCam)
    {
        int priority = pasteCam.m_Priority;
        Transform follow = pasteCam.m_Follow;
        Transform aim = pasteCam.m_LookAt;
        foreach (FieldInfo field in copyCam.GetType().GetFields(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
        {
            if (!field.IsInitOnly && !field.IsLiteral)
            {
                field.SetValue(pasteCam, field.GetValue(copyCam));
            }
        }

        foreach (PropertyInfo property in copyCam.GetType().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            if (property.CanWrite && property.Name != "name" && property.Name != "layer")
            {
                property.SetValue(pasteCam, property.GetValue(copyCam));
            }
        }
        pasteCam.transform.position = copyCam.transform.position;
        pasteCam.transform.rotation = copyCam.transform.rotation;
        pasteCam.m_Priority = priority;
        pasteCam.m_Follow = follow;
        pasteCam.m_LookAt = aim;
    }
}
