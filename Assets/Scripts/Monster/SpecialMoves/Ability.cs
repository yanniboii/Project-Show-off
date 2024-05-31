using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] MoveType moveType;
    public Player player;

    public void BeforeSwap()
    {
        player.beforeAbility -= ExecuteAbility;
    }

    public void AfterSwap()
    {
        player.beforeAbility += ExecuteAbility;
    }
    //Implement Move 
    public void ExecuteAbility()
    {
        if (moveType == MoveType.buff)
        {
            gameObject.GetComponent<AbstractBuff>().ApplyBuff();
        }
        //if (moveType == MoveType.passive)
        //{
        //    AbstractPassive pas = gameObject.GetComponent<AbstractPassive>();
        //    if (!pas.enabled)
        //    {
        //        pas.enabled = true;
        //    }
        //}
        //if (moveType == MoveType.active)
        //{
        //    Debug.Log("A");
        //    gameObject.GetComponent<AbstractActive>().ExecuteActive();
        //}
        if (moveType == MoveType.ShootAble)
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
    passive
}
