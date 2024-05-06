using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : AbstractBuff
{
    [SerializeField] float speedIncrease;

    // Update is called once per frame
    void Update()
    {
        UpdateDuration();
    }

    public override void ApplyBuff()
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveBuff()
    {
        throw new System.NotImplementedException();
    }
}
