using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKey : MonoBehaviour
{

  [SerializeField]  AudioSource audioSource;
  void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("keycollectable"))
        {
            audioSource.Play();
            Destroy(other.gameObject);


            OnPrefabCollision();
        }
    }


    void OnPrefabCollision()
    {

        Debug.Log("Prefab collided and destroyed!");

    }
}
