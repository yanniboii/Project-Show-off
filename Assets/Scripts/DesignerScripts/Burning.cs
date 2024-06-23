using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Roots_1" || collision.gameObject.name == "Planks" || collision.gameObject.name == "sweep9" || collision.gameObject.name == "sweep10")
        {
            Destroy(collision.gameObject);
        }
    }
}
