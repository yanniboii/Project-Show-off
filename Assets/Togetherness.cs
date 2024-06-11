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
            t += 0.01f;
            //movingThing.transform.position = new Vector3(Mathf.Lerp(movingThing.transform.position.x, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.y, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.z, movedLocation.x, t));
            movingThing.SetActive(true);
        }
    }
}
