using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togetherness : MonoBehaviour
{
    List<GameObject> buttons = new List<GameObject>();
    public float pressCount;
    public GameObject movingThing;
    [SerializeField] Vector3 movedLocation;
    float t = 0;
    public float moveSpeed;
    Vector3 origin;
    private void Awake()
    {
        foreach(Transform child in transform)
        {
            buttons.Add(child.gameObject);
        }
        origin = movingThing.transform.position;
    }

    private void Update()
    {
        if (pressCount == buttons.Count)
        {
            t += moveSpeed * Time.deltaTime;
            movingThing.transform.position = new Vector3(Mathf.Lerp(movingThing.transform.position.x, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.y, movedLocation.y, t), Mathf.Lerp(movingThing.transform.position.z, movedLocation.z, t));
        }
        else
        {
            t += moveSpeed * Time.deltaTime;
            movingThing.transform.position = new Vector3(Mathf.Lerp(movingThing.transform.position.x, origin.x, t), Mathf.Lerp(movingThing.transform.position.y, origin.y, t), Mathf.Lerp(movingThing.transform.position.z, origin.z, t));
        }
    }

    public void ResetTime()
    {
        t = 0;
    }
}
