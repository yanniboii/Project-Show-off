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
        startScale = transform.parent.localScale;
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
            transform.parent.localScale = Vector3.Lerp(transform.parent.localScale,targetScale, 0.03f);
            if(transform.parent.localScale == targetScale )
            {
                deflate = false;
            }
        }
        else
        {
            if(transform.parent.localScale != startScale)
            {
                transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, startScale, 0.03f);
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
