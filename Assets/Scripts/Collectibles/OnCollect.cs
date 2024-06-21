using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollect : MonoBehaviour
{
    [SerializeField] IntValue collectedCount;
    [SerializeField] List<GameObject> unlocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectedCount.value++;
            unlocks.ForEach(unlocks => { unlocks.SetActive(true); });
            Destroy(gameObject);
        }
    }
}

