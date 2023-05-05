using UnityEngine;
using Photon.Pun;

public class PhotonNetworkManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    private string roomName = "MyRoom"; // ルーム名を指定

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinOrCreateRoom(roomName, new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, null); // ルーム名を指定して接続
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
    }
}