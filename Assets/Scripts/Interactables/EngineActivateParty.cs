using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineActivateParty : MonoBehaviour
{

    [SerializeField] EngineMachine engine;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject enabledObject;
    bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(on!=engine.on){
            // switch states
            on = engine.on;
            
            enabledObject.SetActive(on);
            if(on){
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }

            }else{
                if(audioSource.isPlaying){
                    audioSource.Stop();
                }                

            }

        }
          if (!audioSource.isPlaying && engine.on)
            {
                engine.on = false;
            }
    }
}
