using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using TMPro;
using System.Security.Cryptography;

public class CreateAndJoinRooms : Photon.PunBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public bool ready = false;

   

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.room != null)
        {
            Debug.Log(PhotonNetwork.room.PlayerCount);
            if (PhotonNetwork.room.PlayerCount > 1)
            {
                PhotonNetwork.LoadLevel("Game");
            }
        }
      
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

   
}
