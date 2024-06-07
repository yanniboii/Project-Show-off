using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public GameObject computered;
    bool yeeting = false;
    public GameObject leavingPortal;
    bool oneTimeTrigger = true;

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

        if (yeeting && Input.GetKey(KeyCode.E) && oneTimeTrigger)
        {
            oneTimeTrigger = false;
            StartCoroutine(Yeet());
        }
    }

    public void RemovePuzzle()
    {
        Destroy(computered);
    }

    IEnumerator Yeet()
    {
        //Cheers my brothers
        for (int i = 0; i < 95; i++)
        {
            leavingPortal.transform.position += new Vector3(0, 0.06f, 0);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
