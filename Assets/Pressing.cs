using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressing : MonoBehaviour
{
    private Vector3 scaleChange, positionChange;
    Renderer colour;
    Material Up;
    Material Down;
    private void Awake()
    {
        colour = this.GetComponent<Renderer>();
        foreach(var material in Resources.FindObjectsOfTypeAll(typeof(Material)) as Material[])
        {
            if (material != null && material.name == "ButtonUp")
            {
                Up = material;
            }
            if (material != null && material.name == "ButtonDown")
            {
                Down = material;
            }
        }
    }
    private void Start()
    {
        scaleChange = new Vector3 (0, 0.3f, 0);
        positionChange = new Vector3(0, 0.1f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<Togetherness>().pressCount++;
            this.transform.localScale -= scaleChange;
            colour.material = Down;
            this.transform.position += positionChange;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<Togetherness>().pressCount--;
            this.transform.localScale += scaleChange;
            colour.material = Up;
            this.transform.position -= positionChange;
        }
    }
}
