using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMove : MonoBehaviour
{
    [SerializeField] MoveType moveType;
    //Implement Move 
    public void ExecuteMove()
    {
        if(moveType == MoveType.buff)
        {
            gameObject.GetComponent<AbstractBuff>().ApplyBuff();
        }
        if(moveType == MoveType.passive)
        {
            AbstractPassive pas = gameObject.GetComponent<AbstractPassive>();
            if(!pas.enabled)
            {
                pas.enabled = true;
            }
        }
        if(moveType == MoveType.active)
        {
            gameObject.GetComponent<AbstractActive>().ExecuteActive();
        }
    }
}

public enum MoveType
{
    ShootAble,
    buff,
    passive,
    active
}
