using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class DisconnectServer : MonoBehaviour
{
    // Start is called before the first frame update
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("SelectOffline_Online");
    }

   

    // Update is called once per frame
    
}
