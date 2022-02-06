using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Choose : MonoBehaviourPunCallbacks
{
    public void Demon()
    {
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.JoinRandomRoom();
    }

    public void Hide()
    {
        PhotonNetwork.NickName = "ChasePlayer";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    //部屋に入った時に呼ばれる
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました。");
        //battleシーンをロード
        PhotonNetwork.LoadLevel("Duo");
    }

}
