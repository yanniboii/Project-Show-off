using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


[CreateAssetMenu(fileName = "IntValue", menuName = "Values/IntValue")]

public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;
    public int value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}