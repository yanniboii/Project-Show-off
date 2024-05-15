using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayers : MonoBehaviour
{
    public PlayerInputManager input;
    [SerializeField] InputDevice inputDevice1;
    [SerializeField] InputDevice inputDevice2;
    [SerializeField] InputDevice inputDevice3;
    [SerializeField] InputDevice inputDevice4;

    // Start is called before the first frame update
    void Start()
    {
        input.EnableJoining();
        input.JoinPlayer(0,0,null, inputDevice1);
        input.JoinPlayer(1, 0, null, inputDevice2);
        input.JoinPlayer(2, 0, null, inputDevice3);
        input.JoinPlayer(3, 0, null, inputDevice4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
