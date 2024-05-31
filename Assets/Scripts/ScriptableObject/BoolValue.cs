using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


[CreateAssetMenu(fileName = "BoolValue", menuName = "Values/BoolValue")]

public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;
    public bool value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
