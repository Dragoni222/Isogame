using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.SceneManagement;
public class ConenctToServer : Photon.PunBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(2f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("now");
        PhotonNetwork.ConnectUsingSettings("1");
        //Your Function You Want to Call
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("joined");
        SceneManager.LoadScene("Lobby");
    }
}
