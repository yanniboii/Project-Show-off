using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

public class JoinPlayers : MonoBehaviour
{
    public PlayerInputManager input;
    [SerializeField] GameObject playerPrefab;
    int joinIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //InputSystem.onDeviceChange += (device, change) =>
        //{
        //    if(change == InputDeviceChange.Added)
        //    {
        //        input.JoinPlayer(joinIndex, 0, null, device);
        //        GameObject player = Instantiate(playerPrefab);
        //        PlayerInput.Instantiate(playerPrefab, joinIndex,null,-1, device);
        //        joinIndex++;
        //    }
        //};
        List<InputDevice> devices = InputSystem.devices.ToList();
        foreach (InputDevice device in devices)
        {
            Debug.Log(device.ToString());
            if (device.description.empty) 
            {
                Debug.Log("empty");
                return; 
            }
//            if(InputSettings.supportedDevices.Contains(device.layout))
            input.JoinPlayer(joinIndex, 0, null, device);
            GameObject player = Instantiate(playerPrefab);
            PlayerInput.Instantiate(playerPrefab, joinIndex, null, -1, device);
            joinIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
