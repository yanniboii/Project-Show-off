using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressing : MonoBehaviour
{
    private Vector3 scaleChange, positionChange;
    Renderer colour;
    [SerializeField] Material Up, Down;
    public bool oneTimeTrigger;
    bool notTriggered = true;
    private void Awake()
    {
        colour = this.GetComponent<Renderer>();
    }
    private void Start()
    {
        scaleChange = new Vector3 (0, 0.3f, 0);
        positionChange = new Vector3(0, 0.1f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && notTriggered)
        {
            this.GetComponentInParent<Togetherness>().pressCount++;
            this.transform.localScale -= scaleChange;
            colour.material = Down;
            this.transform.position += positionChange;
            if(oneTimeTrigger)
            {
                notTriggered = false;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!oneTimeTrigger)
            {
                this.GetComponentInParent<Togetherness>().pressCount--;
                this.transform.localScale += scaleChange;
                colour.material = Up;
                this.transform.position -= positionChange;
                notTriggered = true;
            }
        }
    }
}
