using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractBuff : MonoBehaviour
{
    [Tooltip("The Amount of deltaTime that the buff is active")]
    public float duration = 2;
    [Tooltip("You can use this to scale the buff")]
    public float magnitude = 1;

    public abstract void ApplyBuff();

    public abstract void RemoveBuff();

    public virtual void UpdateDuration()
    {
        duration -= Time.deltaTime;

        if (duration <= 0f)
        {
            RemoveBuff();
        }
    }
}
