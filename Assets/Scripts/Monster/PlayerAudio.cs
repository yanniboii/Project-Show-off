using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip audioShoot;
    [SerializeField] AudioClip audioJump;
    [SerializeField] AudioClip audioTalk;
    [SerializeField] AudioClip audioDeath;
    [SerializeField] AudioClip audioWander;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayShoot(){PlaySound(audioShoot);}
    public void PlayJump(){PlaySound(audioJump);}
    public void PlayTalk(){PlaySound(audioTalk);}
    public void PlayWander(){PlaySound(audioWander);}
    public void PlayDeath(){PlaySound(audioDeath);}

    void PlaySound(AudioClip sound){
       if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
