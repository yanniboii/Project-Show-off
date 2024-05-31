using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togetherness : MonoBehaviour
{
    List<GameObject> buttons = new List<GameObject>();
    public float pressCount;
    public GameObject movingThing;
    [SerializeField] Vector3 movedLocation;

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
            //TODO Idk man like..... it's gone! Just not to the right place
            movingThing.transform.position = movedLocation;
            //movingThing.transform.position = new Vector3(Mathf.Lerp(movingThing.transform.position.x, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.y, movedLocation.x, t), Mathf.Lerp(movingThing.transform.position.z, movedLocation.x, t));
        }
    }
}
