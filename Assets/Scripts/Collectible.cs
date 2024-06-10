using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Quaternion rotationSpeed;
    float coinCount;
    public GameObject slider;
    void Update()
    {
        transform.rotation = transform.rotation * rotationSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        coinCount++;
        slider.GetComponent<CoinProgress>().UpdateProgress();
    }
}
