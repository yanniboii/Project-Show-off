using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMachine : MonoBehaviour
{
    Vector3 OriginalSize;
    float randomamount = 0.15f;
    float changetime = 0;
    float changemoment = 0.06f;
    public bool on = true;
    Light lightComp;
    float lightIntensity;

    // Start is called before the first frame update
    void Start()
    {
        OriginalSize = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        lightComp = GetComponent<Light>();
        lightIntensity = lightComp.intensity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(on){
            changetime += Time.deltaTime;
            if(changetime>changemoment){
            transform.localScale = new Vector3(OriginalSize.x+Random.Range(-randomamount,randomamount),OriginalSize.y+Random.Range(-randomamount,randomamount),OriginalSize.z+Random.Range(-randomamount,randomamount));
            changetime = 0;
            }

            lightComp.intensity = lightIntensity;
        }else{
            lightComp.intensity = 0;
            transform.localScale = OriginalSize;
        }
    }

    public void SwitchOn(){
        on = !on;
    }
}
