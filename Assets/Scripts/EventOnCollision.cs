using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    [SerializeField] OnCollision onCollision;
    [SerializeField] List<GameObject> triggerObjects = new List<GameObject>();
    bool called =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("yo");
        for(int i = 0; i < triggerObjects.Count; i++)
        {
            Debug.Log("oy");
            if (other.gameObject.name == triggerObjects[i].name || other.gameObject.name == triggerObjects[i].name + " (clone)")
            {
                Debug.Log("yoy");
                onCollision.Invoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class OnCollision : UnityEvent
{

}