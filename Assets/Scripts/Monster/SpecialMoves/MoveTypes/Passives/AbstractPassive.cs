using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractPassive : MonoBehaviour
{
    [Tooltip("You can use this to scale the passive")]
    public float magnitude = 1;

    public abstract void ApplyPassive();

    public abstract void RemovePassive();
}