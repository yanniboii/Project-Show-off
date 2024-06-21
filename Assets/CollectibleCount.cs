using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    public float totalCollectible;
    //This doesn't need to be serialized, I just do it to check everything's working
    [SerializeField] List<GameObject> allCollectibles = new List<GameObject>();
    [SerializeField] float collected;
    [SerializeField] TMP_Text score;
    public float fadeSpeed = 0;
    //This one is seralized because we have specific amounts of levels and allat
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    public Image lowTaperFade;
    [SerializeField] List<GameObject> portals = new List<GameObject>();
    public List<GameObject> bridges = new List<GameObject>();
    float bridgeCount = 0;
    float unlockCount = 0;
    int currentLevel;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        lowTaperFade.color = new Color(0, 0, 0, 1);
        foreach (var gameObj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "KeyCollectable" && !EditorUtility.IsPersistent(gameObj.transform.root.gameObject))
            {
                allCollectibles.Add(gameObj);
            }
            else if (gameObj.name == "Portal" && !EditorUtility.IsPersistent(gameObj.transform.root.gameObject))
            {
                portals.Add(gameObj);
            }
        }
        foreach(var i in allCollectibles)
        {
            Debug.Log(i.transform.position.ToString());
        }
        totalCollectible = allCollectibles.Count;
        StartCoroutine(fadeIn());
        currentLevel = 0;
    }

    private void Update()
    {
        collected = totalCollectible - allCollectibles.Count;
        score.color = new Color(1, 1, 1, fadeSpeed);
        score.text = new string($"{collected} / {totalCollectible}");
        CheckDestroyed();
    }

    void CheckDestroyed()
    {
        foreach (var gameObj in allCollectibles)
        {
            if (gameObj == null)
            {
                //fadeSpeed = 1;
                unlockCount++;
                bridgeCount++;
                StartCoroutine(DisplayCollectibles());
                allCollectibles.RemoveAt(allCollectibles.IndexOf(gameObj));
                if (currentLevel < levels.Count)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        levels[currentLevel].gameObject.SetActive(true);
                        currentLevel++;
                    }
                }
                if (unlockCount == 2f)
                {
                    StartCoroutine(UnlockBig());
                }
                if (bridgeCount == 4f)
                {
                    StartCoroutine(RaiseBridge());
                }
            }
        }
    }
    
    IEnumerator UnlockBig()
    {
        Debug.Log("Unlocking");
        if (portals[0] != null)
        {
            GameObject nextBigLevel = portals[0];
            for (int i = 0; i < 200; i++)
            {
                nextBigLevel.transform.position += new Vector3(0, 0.06f, 0);
                yield return new WaitForSecondsRealtime(0.01f);
            }
            portals.RemoveAt(0);
            unlockCount = 0;
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator DisplayCollectibles()
    {
        score.color = new Color(1, 1, 1, 1);
        fadeSpeed = 1;
        yield return new WaitForSeconds(0.5f);
        for (int i = 100; i > 0; i--)
        {
            fadeSpeed -= 0.01f;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(0.5f);
        for (float i = 1; i > 0; i -= 0.01f)
        {
            float frameRate = 1 / 60;
            lowTaperFade.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(frameRate);
        }
    }

    IEnumerator RaiseBridge()
    {
        GameObject nextBridge = bridges[0];
        for (int i = 0; i < 115; i++)
        {
            nextBridge.transform.position += new Vector3(0, 0.06f, 0);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        bridges.RemoveAt(0);
        bridgeCount = 0;
    }
}

//Jinkies! That's a lot of lists Fred! We can't stay here! The for loops will keep us here FOREVER!
//Jeepers Velma! Why didn't you think of that BEFORE you turned us into ones and zeroes?
//Well it's not entirely my fault. I thought that Fred was a pro at these things.
//Velma. We were hired to enter someone's code to sort out a ghost,
//we have a talking dog that lives on the largest sandwiches ever made and apparently shares around 90% of his braincells with a person who's constantly high,
//and I don't have a catchphrase.
//Never make any assumptions on what I can do.
//Now that's not my fault. You're the plans guy.
//That's your mistake. I'm not the plans guy, I'm the TRAPS guy. As you should've realised, I am a moron when it comes to coding C#.
//So how are you going to get us out of this then Fred?
//Daphne, I'd love to get us out. As I said, I can't code. Also, there's apparently a specter in the code.
//Like, zoinks guys! Scoob is being chased by a man holding the line of binary 01100001 01111000 01100101!
//Jinkies once again! Fred, break us out of these for loops now!
//Raggy! Re's rafter me! I rooked it up ronrine. Re's rolding a raxe!
