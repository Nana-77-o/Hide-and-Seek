using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Generation : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.NickName == "Player")
        {
            Demon();
        }
        if (PhotonNetwork.NickName == "ChasePlayer")
        {
            Hide();
        }
    }
    private void Demon()
    {
        var position = new Vector3(105, 0f, 41);
        GameObject cart = PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
    }

    private void Hide()
    {
        var position = new Vector3(111.3f, 5, 66.36f);
        GameObject cart = PhotonNetwork.Instantiate("ChasePlayer", position, Quaternion.identity);
    }
}
