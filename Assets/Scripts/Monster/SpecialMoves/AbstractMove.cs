using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMove : MonoBehaviour
{
    [SerializeField] MoveType moveType;
    //Implement Move 
    void ExecuteMove()
    {
        if(moveType == MoveType.buff)
        {
            gameObject.GetComponent<AbstractBuff>().ApplyBuff();
        }
    }
}

public enum MoveType
{
    ShootAble,
    buff,
    passive
}
