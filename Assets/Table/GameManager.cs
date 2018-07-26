using Photon;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : PunBehaviour {

    static string BALL_PREFAB_NAME = "Ball";
    static float BALL_X = 0.0f;
    static float BALL_Y = 1.0f;
    static float BALL_Z = 0.0f;
    static string GAME_VERSION = "0.1.0";
    static byte MAX_PLAYERS = 2;

    void Start () {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.ConnectUsingSettings(GAME_VERSION);
    }

    public override void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.Log("Failed to Connect To Photon");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MAX_PLAYERS }, null);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        PhotonNetwork.Instantiate(BALL_PREFAB_NAME, new Vector3(BALL_X, BALL_Y, BALL_Z), Quaternion.identity, 0);
        var serve = GameObject.Find("Serve");
        var button = serve.GetComponent<Button>();
        button.interactable = true;
    }
}
