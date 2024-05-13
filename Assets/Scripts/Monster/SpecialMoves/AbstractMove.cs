using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMove : MonoBehaviour
{
    [SerializeField] MoveType moveType;
    [SerializeField] float specialInput;
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
        if(moveType == MoveType.ShootAble)
        {
            Debug.Log("A");
            if (gameObject.GetComponent<Shoot>().canShoot)
            {
                Debug.Log("B");
                gameObject.GetComponent<Shoot>().ShootBullet();
            }
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
