using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCheckpoint : MonoBehaviour
{
    public Vector3 resetPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = resetPoint;
        }
    }
}
