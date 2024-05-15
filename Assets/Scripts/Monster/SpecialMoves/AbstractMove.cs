using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbstractMove : MonoBehaviour
{
    [SerializeField] MoveType moveType;

    //Implement Move 
    public void ExecuteMove(InputAction.CallbackContext context)
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
            Debug.Log("A");
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
