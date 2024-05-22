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
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private List<GameObject> monsterPrefab;
    [SerializeField] private float timeUntilInactive;
    [SerializeField] private List<PlayerInfo> playerInfos = new List<PlayerInfo>();

    [SerializeField] private BoolValue AllCharactersInactive;
    #endregion

    #region private vars
    private List<GameObject> players = new List<GameObject>();
    private int joinIndex = 0;
    private bool stopUpdatingInactive = false;
    #endregion

    #endregion

    #region unity functions
    void Awake()
    {
        InstantiateAllPlayers();
    }

    private void OnEnable()
    {
        Player.beforeSwapCharacter += SwapCharacter;
    }

    private void OnDisable()
    {
        Player.beforeSwapCharacter -= SwapCharacter;
    }

    private void Update()
    {
        UpdateInactive();
        CheckIfAllInactive();
    }

    #endregion

    #region private functions
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

            PlayerInput playerInput = PlayerInput.Instantiate(playerPrefab, joinIndex, null, -1, device);

            GameObject go = playerInput.gameObject;

            go.GetComponent<Player>().followObject = monsterPrefab[joinIndex];

            monsterPrefab[joinIndex].GetComponent<BasicMovement>().player = go.GetComponent<Player>();
            monsterPrefab[joinIndex].GetComponent<Ability>().player = go.GetComponent<Player>();
            monsterPrefab[joinIndex].GetComponent<BasicMovement>().AfterSwap();
            monsterPrefab[joinIndex].GetComponent<Ability>().AfterSwap();


            players.Add(go);

            PlayerInfo info = new PlayerInfo();

            info.monsterGO = monsterPrefab[joinIndex];
            info.inputDevice = device;
            info.index = joinIndex;
            info.isActive = true;
            info.timeUntilInactive = timeUntilInactive;

            playerInfos.Add(info);

            joinIndex++;
        }
    }

    void UpdateInactive()
    {
        if (stopUpdatingInactive) return;
        for (int i = 0; i < playerInfos.Count; i++)
        {
            PlayerInfo playerInfo = playerInfos[i];
            if (playerInfo.timeUntilInactive > 0)
            {
                playerInfo.timeUntilInactive -= Time.deltaTime;
            }

            if (playerInfo.timeUntilInactive <= 0 && playerInfo.isActive)
            {
                playerInfo.previousMonsterGO = playerInfo.monsterGO;
                playerInfo.previousPlayer = playerInfo.previousMonsterGO.GetComponent<BasicMovement>().player;

                playerInfo.previousPlayer.followObject = null;

                playerInfo.isActive = false;
                playerInfo.monsterGO = null;

                playerInfo.previousMonsterGO.GetComponent<BasicMovement>().BeforeSwap();
                playerInfo.previousMonsterGO.GetComponent<Ability>().BeforeSwap();

                playerInfo.previousMonsterGO.GetComponent<BasicMovement>().player = null;
                playerInfo.previousMonsterGO.GetComponent<Ability>().player = null;
            }

            if (playerInfo.inputDevice.wasUpdatedThisFrame)
            {
                playerInfo.timeUntilInactive = timeUntilInactive;

                playerInfo.isActive = true;
                bool canUsePreviousGameObject = true;
                if (playerInfo.monsterGO == null)
                {

                    if (playerInfo.previousMonsterGO.GetComponent<BasicMovement>().player != null) canUsePreviousGameObject = false;

                    if (canUsePreviousGameObject)
                    {
                        playerInfo.monsterGO = playerInfo.previousMonsterGO;


                        playerInfo.previousMonsterGO.GetComponent<BasicMovement>().player = playerInfo.previousPlayer;
                        playerInfo.previousMonsterGO.GetComponent<Ability>().player = playerInfo.previousPlayer;

                        playerInfo.previousMonsterGO.GetComponent<BasicMovement>().player.followObject = playerInfo.previousMonsterGO;

                        playerInfo.previousMonsterGO.GetComponent<BasicMovement>().AfterSwap();
                        playerInfo.previousMonsterGO.GetComponent<Ability>().AfterSwap();
                    }
                    else
                    {
                        for (int k = 0; k < monsterPrefab.Count; k++)
                        {
                            if (monsterPrefab[k].GetComponent<BasicMovement>().player == null)
                            {
                                playerInfo.monsterGO = monsterPrefab[k];

                                playerInfo.monsterGO.GetComponent<BasicMovement>().player = playerInfo.previousPlayer;
                                playerInfo.monsterGO.GetComponent<Ability>().player = playerInfo.previousPlayer;

                                playerInfo.monsterGO.GetComponent<BasicMovement>().player.followObject = playerInfo.monsterGO;

                                playerInfo.monsterGO.GetComponent<BasicMovement>().AfterSwap();
                                playerInfo.monsterGO.GetComponent<Ability>().AfterSwap();
                                playerInfos[i] = playerInfo;
                                return;
                            }
                        }
                        break;

                    }
                }

            }
            playerInfos[i] = playerInfo;

        }
    }

    void CheckIfAllInactive()
    {
        bool AllInactive = true;
        for (int i = 0; i < playerInfos.Count; i++)
        {
            if (playerInfos[i].isActive)
            {
                AllInactive = false;
            }
            else
            {
                List<GameObject> activeGO = new List<GameObject>();
                for(int j = 0; j < playerInfos.Count; j++)
                {
                    if (playerInfos[i].isActive)
                    {
                        activeGO.Add(playerInfos[i].monsterGO);
                    }
                    for(int k = 0; k < monsterPrefab.Count; k++)
                    {
                        if (!playerInfos[i].ContainsGameObject(monsterPrefab[k]) && activeGO.Contains(monsterPrefab[k])) 
                        {
                            activeGO.Add(monsterPrefab[k]);
                        }
                    }
                }
                playerInfos[i].monsterGO.GetComponent<InactiveMovement>().MoveToClosestPlayer(activeGO);
            }
        }
        if(AllInactive)
        {
            AllCharactersInactive.value = true;
        }
        else
        {
            AllCharactersInactive.value = false;
        }
    }
    #endregion

    #region public functions

    public GameObject SwapCharacter(GameObject gameObject)
    {
        stopUpdatingInactive = true;
        PlayerInfo playerInfo = new PlayerInfo();

        for (int j = 0; j < playerInfos.Count; j++)
        {
            if (!playerInfos[j].ContainsGameObject(gameObject))
            {
                continue;
            }
            playerInfo = playerInfos[j];
            for (int i = 0; i < monsterPrefab.Count; i++)
            {
                int index = playerInfo.index + i;

                if (index >= 4)
                {
                    index = 0;
                }
                if (monsterPrefab[index].GetComponent<BasicMovement>().player == null)
                {
                    Debug.Log(index);
                    //set new index in playerinfo
                    playerInfo.index = index;

                    Player player = playerInfo.monsterGO.GetComponent<BasicMovement>().player;
                    player.followObject = monsterPrefab[index];

                    //old monsterGO
                    playerInfo.monsterGO.GetComponent<BasicMovement>().BeforeSwap();
                    playerInfo.monsterGO.GetComponent<Ability>().BeforeSwap();

                    playerInfo.monsterGO.GetComponent<BasicMovement>().player = null;
                    playerInfo.monsterGO.GetComponent<Ability>().player = null;

                    //new monsterGO
                    playerInfo.monsterGO = monsterPrefab[index];

                    playerInfo.monsterGO.GetComponent<BasicMovement>().player = player;
                    playerInfo.monsterGO.GetComponent<Ability>().player = player;

                    playerInfo.monsterGO.GetComponent<BasicMovement>().AfterSwap();
                    playerInfo.monsterGO.GetComponent<Ability>().AfterSwap();

                    playerInfos[j] = playerInfo;

                    stopUpdatingInactive = false;
                    return monsterPrefab[index];
                }
                else if (index == 0)
                {
                    index++;
                    if (monsterPrefab[index].GetComponent<BasicMovement>().player == null)
                    {
                        Debug.Log(index);
                        //set new index in playerinfo
                        playerInfo.index = index;

                        Player player = playerInfo.monsterGO.GetComponent<BasicMovement>().player;
                        player.followObject = monsterPrefab[index];

                        //old monsterGO
                        playerInfo.monsterGO.GetComponent<BasicMovement>().BeforeSwap();
                        playerInfo.monsterGO.GetComponent<Ability>().BeforeSwap();

                        playerInfo.monsterGO.GetComponent<BasicMovement>().player = null;
                        playerInfo.monsterGO.GetComponent<Ability>().player = null;

                        //new monsterGO
                        playerInfo.monsterGO = monsterPrefab[index];

                        playerInfo.monsterGO.GetComponent<BasicMovement>().player = player;
                        playerInfo.monsterGO.GetComponent<Ability>().player = player;

                        playerInfo.monsterGO.GetComponent<BasicMovement>().AfterSwap();
                        playerInfo.monsterGO.GetComponent<Ability>().AfterSwap();

                        playerInfos[j] = playerInfo;

                        stopUpdatingInactive = false;
                        return monsterPrefab[index];
                    }
                }

            }

        }
        stopUpdatingInactive = false;
        Debug.Log("No Available Character");
        return gameObject;
    }

    #endregion

    #region from Unity
    //YOINKED FROM THE PLAYERINPUTMANGER
    private bool IsDeviceUsableWithPlayerActions(InputDevice device)
    {
        Debug.Assert(device != null);

        if (monsterPrefab[joinIndex] == null)
            return true;

        var playerInput = monsterPrefab[joinIndex].GetComponentInChildren<PlayerInput>();
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
    public GameObject monsterGO;
    public GameObject previousMonsterGO;
    public InputDevice inputDevice;
    public Player previousPlayer;

    public int index;

    public bool isActive;

    public float timeUntilInactive;

    public bool ContainsGameObject(GameObject go)
    {
        if (monsterGO == go) return true;
        else return false;
    }
}