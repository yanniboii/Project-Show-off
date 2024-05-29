using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    public float totalCollectible;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        List<GameObject> allCollectibles = new List<GameObject>();
        foreach (var gameObj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "KeyCollectable" && !EditorUtility.IsPersistent(gameObj.transform.root.gameObject))
            {
                allCollectibles.Add(gameObj);
            }
        }
        foreach(var i in allCollectibles)
        {
            Debug.Log(i.transform.position.ToString());
        }
        totalCollectible = allCollectibles.Count;
    }
}
