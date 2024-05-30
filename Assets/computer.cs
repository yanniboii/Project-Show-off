using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public GameObject computered;
    bool yeeting = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            yeeting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yeeting = false;
        }
    }

    private void Update()
    {
        if (yeeting && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(Yeet());
        }
    }

    IEnumerator Yeet()
    {
        //Cheers my brothers
        float speed = 0.3f;
        for (int i = 0; i < 5; i++)
        {
            speed *= 0.95f;
            computered.transform.position += new Vector3(computered.transform.position.x, 5, computered.transform.position.z);
            yield return new WaitForSeconds(speed);
        }
        for (int i = 0; i < 45; i++)
        {
            computered.transform.position += new Vector3(computered.transform.position.x, 5, computered.transform.position.z);
            yield return new WaitForSeconds(speed);
        }
        Destroy(computered);
    }
}
