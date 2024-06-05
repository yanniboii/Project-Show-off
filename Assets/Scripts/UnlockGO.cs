using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockGO : MonoBehaviour
{
    [SerializeField] Unlock unlock;
    [SerializeField] List<GameObject> triggerObjects = new List<GameObject>();
    bool called =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < triggerObjects.Count; i++)
        {
            if(other.gameObject == triggerObjects[i])
            {
                unlock?.Invoke();
            }
        }
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