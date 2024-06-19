using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    public Vector3 flyPosition;
    Vector3 origin;
    float t;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        origin = this.transform.position;
        //StartCoroutine(ChangePosition());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, flyPosition.x, t), Mathf.Lerp(transform.position.y, flyPosition.y, t), Mathf.Lerp(transform.position.z, flyPosition.z, t));
        t += speed;

        if (transform.position == flyPosition)
        {
            flyPosition = origin;
            origin = this.transform.position;
            t = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && t != 0)
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && t != 0)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    /*IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds (1f);
        do
        {
        }
        while (t < 1);
        yield return new WaitForSecondsRealtime(0.8f);
        flyPosition = origin;
        origin = transform.position;
        t = 0;
        StartCoroutine (ChangePosition());
    }*/
}
