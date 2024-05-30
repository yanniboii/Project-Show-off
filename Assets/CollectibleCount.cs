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
    float collected = 0;
    [SerializeField] TMP_Text score;
    bool fading;
    public float fadeSpeed = 0;
    //This one is seralized because we have specific amounts of levels and allat
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    bool openingWorld;
    public Image lowTaperFade;
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
        }
        foreach(var i in allCollectibles)
        {
            Debug.Log(i.transform.position.ToString());
        }
        totalCollectible = allCollectibles.Count;
        StartCoroutine(fadeIn());
    }

    private void Update()
    {
        score.color = new Color(1, 1, 1, fadeSpeed);
        if (fading)
        {
            fadeSpeed -= 0.01f;
        }
        if (fadeSpeed <= 0)
        {
            fading = false;
        }
        CheckDestroyed();
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

    void CheckDestroyed()
    {
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
        foreach (var i in levels)
        {
            if (i == null)
            {
                levels.RemoveAt(levels.IndexOf(i));
            }
        }
        foreach (var gameObj in allCollectibles)
        {
            if (gameObj == null)
            {
                allCollectibles.RemoveAt(allCollectibles.IndexOf(gameObj));
                collected++;
                score.text = new string($"{collected} / {totalCollectible}");
                StartCoroutine(DisplayCollectibles());
                fadeSpeed = 1;
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
}
