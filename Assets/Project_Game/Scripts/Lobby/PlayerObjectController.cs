using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Steamworks;

public class PlayerObjectController : NetworkBehaviour
{
    //PlayerData
    [SyncVar] public int ConnnectID;
    [SyncVar] public int PlayerIdNumber;
    [SyncVar] public ulong PlayerSteamID;
    [SyncVar(hook = nameof(PLayerNameUpdate))]
    public string PlayerName;
    [SyncVar(hook = nameof(PlayerReadyUpdate))]
    public bool isReady;

    private MyNetworkManager manager;

    private MyNetworkManager Manager
    {
        get
        {
            if (manager != null)
            {
                return manager;
            }
            return manager = MyNetworkManager.singleton as MyNetworkManager;
        }
    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [Command]
    private void CmdSetPlayerReady()
    {
        this.PlayerReadyUpdate(this.isReady, !this.isReady);
    }
    public void ChangeReady()
    {
        if (hasAuthority)
        {
            CmdSetPlayerReady();
        }
    }
    public override void OnStartAuthority()
    {
        CmdSetPlayerName(SteamFriends.GetPersonaName().ToString());
        gameObject.name = "LocalGamePlayer";
        LobbyController.Instance.FindLocalPlayer();
        LobbyController.Instance.UpdateLobbyName();

    }
    public override void OnStartClient()
    {
        Manager.GamePlayers.Add(this);
        LobbyController.Instance.UpdateLobbyName();
        LobbyController.Instance.UpdatePlayerList();
    }
    public override void OnStopClient()
    {
        Manager.GamePlayers.Remove(this);
        LobbyController.Instance.UpdatePlayerList();
    }

    [Command]
    private void CmdSetPlayerName(string PlayerName)
    {
        this.PLayerNameUpdate(this.PlayerName, PlayerName);
    }
    public void PLayerNameUpdate(string oldValue, string newValue)
    {
        if (isServer) // Host
        {
            this.PlayerName = newValue;
        }
        if (isClient) // Client
        {
            LobbyController.Instance.UpdatePlayerList();
        }
    }
    public void PlayerReadyUpdate(bool oldValue, bool newValue)
    {
        if (isServer)
        {
            this.isReady = newValue;
        }
        if (isClient)
        {
            LobbyController.Instance.UpdatePlayerList();
        }
    }
    public void CanStartGame(string SceneName)
    {
        if (hasAuthority)
        {
            CmdCanStartGame(SceneName);
        }
        
    }
    [Command]
    public void CmdCanStartGame(string SceneName)
    {
        Manager.StartGame(SceneName);
    }
}
