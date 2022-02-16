using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Photon.Pun;

public class PlayeIvent : MonoBehaviourPunCallbacks
{
    /// <summary>隠れる場所のレイヤー</summary>
    [SerializeField] LayerMask _hideLayerMask = default;
    /// <summary>アイテムのレイヤー</summary>
    [SerializeField] LayerMask _itemLayerMask = default;
    /// <summary>照準のオブジェクト</summary>
    [SerializeField] GameObject _crosshair = default;
    /// <summary>弾/レーザーを発射する地点を設定する</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>レーザーの射程距離</summary>
    [SerializeField] float _shootRange = 5f;
    ///<summary>アイテムキャンバスObj</summary>
    [SerializeField] GameObject _itemeCanvas;
    ///<summary>レーダーキャンバスObj</summary>
    [SerializeField] GameObject _radarCanvas;
    [SerializeField] Obtainable _radarObj; // 取得可能クラスのオブジェクト
    [SerializeField] GameObject _radarImage;

    /// <summary>メインカメラ</summary>
    [SerializeField] GameObject _mineCam;
    /// <summary>レーダーを使った時のカメラ</summary>
    [SerializeField] GameObject _radarCam;

    private PhotonView _myPhotonView;
    float _timer = 3.0f;
    bool _timerBool = false;
    bool _itemCanvasB = false;
    bool _radarCanvasB = false;
    bool _itemGet;
    void Start()
    {
        // _myPhotonView = GetComponent<PhotonView>();
        // if (_myPhotonView.IsMine)
        {
            //カーソルの非表示
            Cursor.visible = false;
            //カーソルを画面中央にロックする
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        //if (_myPhotonView.IsMine)
        {
            ItemLayer();
        }
        //レーダーを取った時
        if (Input.GetButtonDown("Fire2") && _radarCanvasB)
        {
            _radarCanvasB = false;
            _radarCanvas.SetActive(false);
        }
        //レーダーを使った
        if (Input.GetKeyDown(KeyCode.Q) && _itemGet)
        {
            _radarImage.SetActive(false);
            RadarUse();
            _itemGet = false;
            _timerBool = true;
        }
        if (_timerBool)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _mineCam.SetActive(true);
                _radarCam.SetActive(false);
                if (_timer < -1)
                {
                    _timerBool = false;
                    _timer = 3.0f;

                }
            }
        }
        //隠れる時
        if (Input.GetKeyDown(KeyCode.E) && _itemCanvasB)
        {

        }
        if (Input.GetButtonDown("Fire2") && _itemCanvasB)
        {
            _itemCanvasB = false;
            _itemeCanvas.SetActive(false);
        }
    }

    void ItemLayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        RaycastHit hit;
        // Ray が当たったコライダー
        Collider hitCollider;

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, _shootRange, _itemLayerMask))
        {
            // Ray が当たったオブジェクト
            hitCollider = hit.collider;
            if (Input.GetButtonDown("Fire1") && hitCollider.tag == "Radar" && !_radarCanvasB)
            {
                _radarCanvas.SetActive(true);
                RadarHit(hitCollider);                
            }
        }
        if(Physics.Raycast(ray,out hit,_shootRange, _hideLayerMask))
        {
            // Ray が当たったオブジェクト
            hitCollider = hit.collider;
            if (Input.GetButtonDown("Fire1") && hitCollider.tag == "Ivent" &&!_itemCanvasB)
            {
                _itemeCanvas.SetActive(true);
                IventHit(hitCollider);
            }
        }
    }
 
    /// <summary>それぞれが当たった時の処理</summary>
    void RadarHit(Collider collider)
    {
        _radarCanvasB = true;
        Destroy(collider.gameObject);
        Debug.Log("Radarは当たった");
        _radarObj.Obtain(gameObject); // 取得メソッドを呼ぶ
        _itemGet = Inventory._itemeGetFlag;
    }
    void IventHit(Collider collider)
    {
        _itemCanvasB = true;
        Debug.Log("Hideは当たった");
    }

    void RadarUse()
    {
        _mineCam.SetActive(false);
        _radarCam.SetActive(true);
        Debug.Log("れーだーを使った");
    }
}
