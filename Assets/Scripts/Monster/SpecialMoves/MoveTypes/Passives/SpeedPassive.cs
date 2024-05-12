using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPassive : AbstractPassive
{
    float baseSpeed;
    // Start is called before the first frame update
    void OnEnable()
    {
        ApplyPassive();
    }

    public override void ApplyPassive()
    {
        baseSpeed = GetComponent<BasicMovement>().monsterData.speed;
        GetComponent<BasicMovement>().monsterData.speed *= 3;
    }

    public override void RemovePassive()
    {
        GetComponent<BasicMovement>().monsterData.speed /= 3;
    }

    private void OnDisable()
    {
        if(baseSpeed != GetComponent<BasicMovement>().monsterData.speed)
        {
            GetComponent<BasicMovement>().monsterData.speed /= 3;
        }
    }
}
