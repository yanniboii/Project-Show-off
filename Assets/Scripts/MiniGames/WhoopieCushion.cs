using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopieCushion : MonoBehaviour
{
    [SerializeField] Vector3 targetScale;
    Vector3 startScale;
    bool deflate = false;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( deflate)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            transform.localScale = Vector3.Lerp(transform.localScale,targetScale, 0.03f);
            if(transform.localScale == targetScale )
            {
                deflate = false;
            }
        }
        else
        {
            if(transform.localScale != startScale)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, startScale, 0.03f);
            }
        }
    }

    public void StartDeflating()
    {
        if( !deflate)
        {
            deflate = true;
        }
    }
}
