using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public GameObject computered;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Yeet());
        }
    }

    IEnumerator Yeet()
    {
        for (int i = 0; i < 50; i++)
        {
            computered.transform.position += new Vector3(5, 5, 5);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(computered);
    }
}
