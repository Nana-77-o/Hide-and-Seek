using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ChengeScene : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //マスターサーバーへ接続
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターサーバー接続");
    }

    public void SoloPlay()
    {
        SceneManager.LoadScene("");
    }

    public void DuoPlay()
    {
        SceneManager.LoadScene("DuoChoose");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
}
