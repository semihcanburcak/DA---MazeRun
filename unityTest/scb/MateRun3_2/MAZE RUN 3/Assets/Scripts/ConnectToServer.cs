using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connect to Server
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); //This will also allow us to join rooms later on, but for now we are simply joining a lobby
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("SelectLoginRegisterScene");
    }



}
