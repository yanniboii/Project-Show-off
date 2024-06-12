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

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            buttons.Add(child.gameObject);
        }
    }

    private void Update()
    {
        if (pressCount == buttons.Count)
        {
            if (t < 1)
            {
                t += 0.01f;
            }
            if (movingThing.activeSelf == false)
            {
                movedLocation = movingThing.transform.position;
            }
            movingThing.SetActive(true);
            movingThing.transform.position = new Vector3(Mathf.Lerp(movingThing.transform.position.x, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.y, movedLocation.y, t), Mathf.Lerp(movingThing.transform.position.z, movedLocation.z, t));
        }
    }
}
