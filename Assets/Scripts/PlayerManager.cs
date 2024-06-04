using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
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
    [SerializeField] private List<Monster> monsterPrefab;
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
            //Debug.Log(device.ToString());

            PlayerInput playerInput = PlayerInput.Instantiate(playerPrefab, joinIndex, null, -1, device);

            GameObject go = playerInput.gameObject;

            Player player = go.GetComponent<Player>();
            player.followObject = monsterPrefab[joinIndex].gameObject;

            monsterPrefab[joinIndex].GetBasicMovement().player = player;
            monsterPrefab[joinIndex].GetAbility().player = player;
            monsterPrefab[joinIndex].GetBasicMovement().AfterSwap();
            monsterPrefab[joinIndex].GetAbility().AfterSwap();


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
                playerInfo.previousPlayer = playerInfo.previousMonsterGO.GetBasicMovement().player;

                playerInfo.previousPlayer.followObject = null;

                playerInfo.isActive = false;
                playerInfo.monsterGO = null;

                UnsubscribeMonster(playerInfo);
            }

            if (playerInfo.inputDevice.wasUpdatedThisFrame)
            {
                playerInfo.timeUntilInactive = timeUntilInactive;

                playerInfo.isActive = true;
                bool canUsePreviousGameObject = true;
                if (playerInfo.monsterGO == null)
                {

                    if (playerInfo.previousMonsterGO.GetBasicMovement().player != null) canUsePreviousGameObject = false;

                    if (canUsePreviousGameObject)
                    {
                        playerInfo.monsterGO = playerInfo.previousMonsterGO;
                        playerInfo.previousMonsterGO.GetBasicMovement().player.followObject = playerInfo.previousMonsterGO.gameObject;

                        SubscribeMonster(playerInfo,playerInfo.previousPlayer);
                    }
                    else
                    {
                        for (int k = 0; k < monsterPrefab.Count; k++)
                        {
                            if (monsterPrefab[k].GetBasicMovement().player == null)
                            {
                                playerInfo.monsterGO = monsterPrefab[k];
                                playerInfo.monsterGO.GetBasicMovement().player.followObject = playerInfo.monsterGO.gameObject;

                                SubscribeMonster(playerInfo, playerInfo.previousPlayer);
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
        bool AllInactive = playerInfos.All(info => !info.isActive);
        List<GameObject> activeGO = playerInfos.Where(info => info.isActive).Select(info => info.monsterGO.gameObject).ToList();

        for (int k = 0; k < monsterPrefab.Count; k++)
        {
            if (!activeGO.Contains(monsterPrefab[k].gameObject))
            {
                if(!AllInactive)
                {
                    monsterPrefab[k].GetInactiveMovement().MoveToClosestPlayer(activeGO);
                }

            }
        }
        AllCharactersInactive.value = AllInactive;
    }

    void UnsubscribeMonster(PlayerInfo playerInfo)
    {
        playerInfo.monsterGO.GetBasicMovement().BeforeSwap();
        playerInfo.monsterGO.GetAbility().BeforeSwap();

        playerInfo.monsterGO.GetBasicMovement().player = null;
        playerInfo.monsterGO.GetAbility().player = null;
    }

    void SubscribeMonster(PlayerInfo playerInfo, Player player)
    {
        playerInfo.monsterGO.GetBasicMovement().player = player;
        playerInfo.monsterGO.GetAbility().player = player;

        playerInfo.monsterGO.GetBasicMovement().AfterSwap();
        playerInfo.monsterGO.GetAbility().AfterSwap();
        playerInfo.monsterGO.GetInactiveMovement().DisableAgent();
    }

    void UpdateCharacter(PlayerInfo playerInfo, int index, int j)
    {
        //set new index in playerinfo
        playerInfo.index = index;

        Player player = playerInfo.monsterGO.GetBasicMovement().player;
        player.followObject = monsterPrefab[index].gameObject;

        //old monsterGO
        UnsubscribeMonster(playerInfo);

        //new monsterGO
        playerInfo.monsterGO = monsterPrefab[index];
        SubscribeMonster(playerInfo, player);

        playerInfos[j] = playerInfo;

        stopUpdatingInactive = false;
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
                if (monsterPrefab[index].GetBasicMovement().player == null)
                {
                    UpdateCharacter(playerInfo, index, j);
                    return monsterPrefab[index].gameObject;
                }
                else if (index == 0)
                {
                    index++;
                    if (monsterPrefab[index].GetBasicMovement().player == null)
                    {
                        UpdateCharacter(playerInfo, index, j);
                        return monsterPrefab[index].gameObject;
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
    public Monster? monsterGO;
    public Monster? previousMonsterGO;
    public InputDevice? inputDevice;
    public Player? previousPlayer;

    public int index;

    public bool isActive;

    public float timeUntilInactive;

    public bool ContainsGameObject(GameObject go)
    {
        return monsterGO?.gameObject == go;
    }
}