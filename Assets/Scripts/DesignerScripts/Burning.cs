using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Renderer>() != null)
        {
            if (collision.gameObject.GetComponent<Renderer>().material.name == "Woody (Instance)" || collision.gameObject.GetComponent<Renderer>().material.name == "Grassy (Instance)")
            {
                Destroy(collision.gameObject);
                if (this.name == "fireball(Clone)")
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Renderer>() != null)
        {
            if (collision.gameObject.GetComponent<Renderer>().material.name == "Woody (Instance)" || collision.gameObject.GetComponent<Renderer>().material.name == "Grassy (Instance)")
            {
                Destroy(collision.gameObject);
                if (this.name == "fireball(Clone)")
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
