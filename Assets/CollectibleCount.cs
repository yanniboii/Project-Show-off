using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    public float totalCollectible;
    //This doesn't need to be serialized, I just do it to check everything's working
    [SerializeField] List<GameObject> allCollectibles = new List<GameObject>();
    float collected = 0;
    [SerializeField] TMP_Text score;
    bool fading;
    public float fadeSpeed = 0;
    //This one is seralized because we have specific amounts of levels and allat
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    bool openingWorld;
    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    private void Update()
    {
        score.color = new Color(1, 1, 1, fadeSpeed);
        foreach (var gameObj in allCollectibles)
        {
            if (gameObj == null)
            {
                allCollectibles.RemoveAt(allCollectibles.IndexOf(gameObj));
                collected++;
                score.text = new string ($"{collected} / {totalCollectible}");
                StartCoroutine(DisplayCollectibles());
                fadeSpeed = 1;
            }
        }
        if (fading)
        {
            fadeSpeed -= 0.01f;
        }
        if (fadeSpeed <= 0)
        {
            fading = false;
        }
    }

    void moveOn()
    {
        if (openingWorld)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(levels[i].ToString());
                openingWorld = false;
            }
        }
    }

    IEnumerator DisplayCollectibles()
    {
        yield return new WaitForSeconds(0.5f);
        fading = true;
        if (collected >= 5)
        {
            moveOn();
        }
    }
}
