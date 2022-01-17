using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayeIvent : MonoBehaviour
{
    /// <summary>ドアのレイヤー</summary>
    [SerializeField] LayerMask _doorLayerMask = default;
    /// <summary>アイテムのレイヤー</summary>
    [SerializeField] LayerMask _itemLayerMask = default;
    /// <summary>照準のオブジェクト</summary>
    [SerializeField] GameObject _crosshair = default;
    /// <summary>弾/レーザーを発射する地点を設定する</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>レーザーの射程距離</summary>
    [SerializeField] float _shootRange = 5f;
    /// <summary>ドアのアニメーション</summary>
    [SerializeField] UnityEvent _doorAnim= default;
    ///<summary>アイテム取得のアニメーション</summary>
    [SerializeField] UnityEvent _itemAnim = default;
    //　ドアのアニメーター
    public Animator _dooranimator;
    private bool _doorOpen = false;

    void Start()
    {
        //カーソルの非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;
        //_dooranimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_doorOpen)
        {
            _dooranimator.SetBool("Open", !_dooranimator.GetBool("Open"));
        }
        DoorLayer();
        ItemLayer();
    }

    void DoorLayer()
    {
        _doorOpen = false;
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        RaycastHit hit = default;
        // hitPosition は Ray が当たった場所。Line の終点となる。初期値（何にも当たっていない時）は Muzzle から射程距離だけ前方にする。
        //_doorhitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shootRange;
        // Ray が当たったコライダー
        Collider hitCollider = default;

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, _shootRange, _doorLayerMask))
        {
            //_doorhitPosition = hit.point;    // Ray が当たった場所
            hitCollider = hit.collider;    // Ray が当たったオブジェクト
        }
        else
        {
            _doorOpen = false;
        }
        if (Input.GetMouseButtonDown(0))
        {

            if (hitCollider)
            {
                DoorHit(hitCollider);
            }
        }
    }

    void ItemLayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        RaycastHit hit = default;
        // hitPosition は Ray が当たった場所。Line の終点となる。初期値（何にも当たっていない時）は Muzzle から射程距離だけ前方にする。
        //Vector3 hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shootRange;
        // Ray が当たったコライダー
        Collider hitCollider = default;

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, _shootRange, _itemLayerMask))
        {
            //hitPosition = hit.point;    // Ray が当たった場所
            hitCollider = hit.collider;    // Ray が当たったオブジェクト
        }
        else
        {
            //Debug.Log("アイテムはあったってない");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hitCollider)
            {
                ItemHit(hitCollider);
            }
        }
    }

    /// <summary>それぞれが当たった時の処理</summary>
    void ItemHit(Collider collider)
    {
        
        Debug.Log("アイテムは当たった");
    }
    void DoorHit(Collider collider)
    {
        _doorOpen = true;
        _doorAnim.Invoke();
        Debug.Log("ドアは当たった");
    }

}
