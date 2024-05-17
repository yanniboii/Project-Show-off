using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    #region vars

    #region public vars
    public PlayerInputManager input;
    #endregion

    #region Serialized vars
    [SerializeField] private List<GameObject> playerPrefab;
    [SerializeField] private float timeUntilInactive;
    #endregion

    #region private vars
    private int joinIndex = 0;
    [SerializeField]private List<PlayerInfo> playerInfos = new List<PlayerInfo>();
    private List<GameObject> inactiveGO = new List<GameObject>();
    #endregion

    #endregion

    #region unity functions
    void Start()
    {
        InstantiateAllPlayers();
    }

    private void Update()
    {
        UpdateInactive();
    }
    #endregion

    #region functions
    void InstantiateAllPlayers()
    {
        List<InputDevice> devices = InputSystem.devices.ToList();
        foreach (InputDevice device in devices)
        {
            //if (!IsDeviceUsableWithPlayerActions(device)) return; //if it sudenly stops working uncomment this

            if (device.description.empty)
            {
                Debug.Log("empty");
                return;
            }
            Debug.Log(device.ToString());

            PlayerInput.Instantiate(playerPrefab[joinIndex], joinIndex, null, -1, device);

            PlayerInfo info = new PlayerInfo();

            info.gameObject = playerPrefab[joinIndex];
            info.inputDevice = device;
            info.isActive = true;
            info.timeUntilInactive = timeUntilInactive;

            playerInfos.Add(info);
            Debug.Log("D");

            joinIndex++;
        }
    }

    void UpdateInactive()
    {
        for (int i = 0; i < playerInfos.Count; i++)
        {
            PlayerInfo playerInfo = playerInfos[i];
            Debug.Log("A");
            if(playerInfo.timeUntilInactive > 0)
            {
                Debug.Log("B");
                playerInfo.timeUntilInactive -= Time.deltaTime;
            }

            if (playerInfo.timeUntilInactive <= 0)
            {
                playerInfo.isActive = false;
                playerInfo.gameObject = null;
            }

            if (playerInfo.inputDevice.wasUpdatedThisFrame)
            {
                Debug.Log("C");
                playerInfo.timeUntilInactive = timeUntilInactive;

                playerInfo.isActive = true;

                for (int j = 0; j < playerInfos.Count; j++)
                {
                    for(int k = 0; k < playerPrefab.Count; k++)
                    {
                        if (!playerInfos[j].ContainsGameObject(playerPrefab[k]))
                        {
                            playerInfo.gameObject = playerPrefab[k];
                        }
                    }

                }

            }

        }
    }
    #endregion

    #region from Unity
    //YOINKED FROM THE PLAYERINPUTMANGER
    private bool IsDeviceUsableWithPlayerActions(InputDevice device)
    {
        Debug.Assert(device != null);

        if (playerPrefab[joinIndex] == null)
            return true;

        var playerInput = playerPrefab[joinIndex].GetComponentInChildren<PlayerInput>();
        if (playerInput == null)
            return true;

        var actions = playerInput.actions;
        if (actions == null)
            return true;

        // If the asset has control schemes, see if there's one that works with the device plus
        // whatever unpaired devices we have left.
        if (actions.controlSchemes.Count > 0)
        {
            using (var unpairedDevices = InputUser.GetUnpairedInputDevices())
            {
                if (InputControlScheme.FindControlSchemeForDevices(unpairedDevices, actions.controlSchemes,
                    mustIncludeDevice: device) == null)
                    return false;
            }
            return true;
        }

        // Otherwise just check whether any of the maps has bindings usable with the device.
        foreach (var actionMap in actions.actionMaps)
            if (actionMap.IsUsableWithDevice(device))
                return true;

        return false;
    }
    #endregion
}

[System.Serializable]
public struct PlayerInfo
{
    public GameObject gameObject;
    public InputDevice inputDevice;

    public bool isActive;

    public float timeUntilInactive;

    public bool ContainsGameObject(GameObject go)
    {
        if(gameObject == go) return true;
        else return false;
    }
}