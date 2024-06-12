using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VirtualCameraManager))]
public class VirtualCameraManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        VirtualCameraManager virtualCameraManager = (VirtualCameraManager)target;

        virtualCameraManager.UpdateValues();
    }
}
