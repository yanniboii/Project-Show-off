using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKey : MonoBehaviour
{
   BasicMovement movementscript;

  [SerializeField]  AudioSource audioSource;

  void Start (){
    movementscript = GetComponent<BasicMovement>();
  }
  void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("keycollectable"))
        {
            audioSource.Play();
            movementscript.Talk();
            Destroy(other.gameObject);


            OnPrefabCollision();
        }
    }


    void OnPrefabCollision()
    {

        Debug.Log("Prefab collided and destroyed!");

    }
}
