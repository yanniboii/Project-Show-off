using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood") || collision.gameObject.CompareTag("Grass"))
        {
            Destroy(collision.gameObject);
            if(this.name == "fireball(Clone)")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
