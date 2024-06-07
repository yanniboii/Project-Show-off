using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKey : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("keycollectable"))
        {

            Destroy(other.gameObject);


            OnPrefabCollision();
        }
    }


    void OnPrefabCollision()
    {

        Debug.Log("Prefab collided and destroyed!");

    }
}
