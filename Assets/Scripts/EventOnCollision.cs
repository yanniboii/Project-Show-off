using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    [SerializeField] OnCollision onCollision;
    [SerializeField] OnTrigger onTrigger;
    [SerializeField] List<GameObject> triggerObjects = new List<GameObject>();
    [SerializeField] bool destroyTriggerObjects;
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
            if (other.gameObject.name == triggerObjects[i].name || other.gameObject.name == triggerObjects[i].name + "(Clone)")
            {
                Debug.Log("yoy");
                onCollision.Invoke();
                if(destroyTriggerObjects)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yo");
        for (int i = 0; i < triggerObjects.Count; i++)
        {
            Debug.Log("oy");
            if (other.gameObject.name == triggerObjects[i].name || other.gameObject.name == triggerObjects[i].name + "(Clone)")
            {
                Debug.Log("yoy");
                onTrigger.Invoke();
                if (destroyTriggerObjects)
                {
                    Destroy(other.gameObject);
                }
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

[Serializable]
public class OnTrigger : UnityEvent
{

}