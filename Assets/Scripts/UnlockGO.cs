using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockGO : MonoBehaviour
{
    [SerializeField] Unlock unlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        unlock?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Unlock : UnityEvent
{

}