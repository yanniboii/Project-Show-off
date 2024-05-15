using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractActive : MonoBehaviour
{
    [Tooltip("The Amount of deltaTime that the active is on cooldown")]
    public float cooldown = 2;

    public bool onCooldown = false;

    public abstract void ExecuteActive();

    public virtual void UpdateCooldown()
    {
        onCooldown = true;
        float tempcd = cooldown;
        while (onCooldown)
        {
            tempcd -= Time.deltaTime;

            if (tempcd <= 0f)
            {
                onCooldown = false;
            }
        }
    }
}