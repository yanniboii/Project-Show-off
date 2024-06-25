using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineActivateGate : MonoBehaviour
{

    [SerializeField] EngineMachine engine;
    [SerializeField] bool reverse;
    [SerializeField] GameObject Object;
    [SerializeField] float ytransform = -5.0f;
    [SerializeField] float lerpSpeed = 1.0f;
    bool on = false;
    bool useon = false;

    private float targetYPositionDown;
    private float originalYPosition;
    // Start is called before the first frame update
    void Start()
    {
        useon = on;
        if(reverse){useon = !useon;};

        originalYPosition = Object.transform.position.y;
        targetYPositionDown = originalYPosition + ytransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (engine != null)
        {
            if (on != engine.on)
            {
                // switch states
                on = engine.on;
                useon = on;
                if (reverse) { useon = !useon; };



            }

            float targetYPosition = useon ? targetYPositionDown : originalYPosition;
            float newY = Mathf.Lerp(Object.transform.position.y, targetYPosition, Time.deltaTime * lerpSpeed);

            Object.transform.position = new Vector3(Object.transform.position.x, newY, Object.transform.position.z);
            if (Mathf.Abs(Object.transform.position.y - targetYPosition) < 0.01f)
            {
                // Snap to the target position
                Object.transform.position = new Vector3(Object.transform.position.x, targetYPosition, Object.transform.position.z);
            }
        }
    
    
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (on || reverse)
            {
                collision.gameObject.transform.SetParent(this.transform, true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
