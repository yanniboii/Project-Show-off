using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(WaitToDie());
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(5);
        Destroy(this);
       // Debug.Log("I should be dead");
    }

}
