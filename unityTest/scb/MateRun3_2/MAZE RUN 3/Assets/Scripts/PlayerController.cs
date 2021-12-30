using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerController : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>(); 
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }
    
    void CreateController()
    {
      
    }
}
