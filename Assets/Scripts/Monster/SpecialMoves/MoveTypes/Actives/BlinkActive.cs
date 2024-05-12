using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkActive : AbstractActive
{
    public override void ExecuteActive()
    {
        if (!onCooldown)
        {
            UpdateCooldown();
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity += new Vector3(0, 0, 50);
        }
    }
}
