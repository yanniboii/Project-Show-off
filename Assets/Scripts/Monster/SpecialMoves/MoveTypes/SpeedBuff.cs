using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : AbstractBuff
{
    [SerializeField] float speedIncrease;

    bool increased = false;

    // Update is called once per frame
    void Update()
    {
        UpdateDuration();
    }

    public override void ApplyBuff()
    {
        //GetComponent<BasicMovement>().monsterData.speed *= speedIncrease;
        //increased = true;
    }

    public override void RemoveBuff()
    {
        //GetComponent<BasicMovement>().monsterData.speed /= speedIncrease;
        //increased = false;
    }

    private void OnDisable()
    {
        if (increased)
        {
            //GetComponent<BasicMovement>().monsterData.speed /= speedIncrease;
        }
    }
}
