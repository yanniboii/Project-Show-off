using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Vector3 spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnPoint = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        }
    }
}
