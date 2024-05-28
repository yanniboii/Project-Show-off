using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Renderer>() != null && collision.gameObject.GetComponent<Renderer>().material.name == "Woody (Instance)")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponentInChildren<Renderer>(true).material.name == "Woody (Instance)")
        {
            Destroy(collision.gameObject);
            if (this.name == "fireball(Clone)")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
