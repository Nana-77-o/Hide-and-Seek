using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayeIvent : MonoBehaviour
{
    /// <summary>ドアのレイヤー</summary>
    //[SerializeField] LayerMask _doorLayerMask = default;
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

    void Start()
    {
        //カーソルの非表示
        Cursor.visible = false;
        //カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        //DoorLayer();
        ItemLayer();
    }

    //void DoorLayer()
    //{
    //    //_doorOpen = false;
    //    Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
    //    RaycastHit hit = default;
    //    // Ray が当たったコライダー
    //    Collider hitCollider = default;

    //    // Ray が何かに当たったか・当たっていないかで処理を分ける        
    //    if (Physics.Raycast(ray, out hit, _shootRange, _doorLayerMask))
    //    {
    //        //_doorhitPosition = hit.point;    // Ray が当たった場所
    //        hitCollider = hit.collider;    // Ray が当たったオブジェクト
    //    }
    //}

    void ItemLayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        RaycastHit hit = default;
        // Ray が当たったコライダー
        Collider hitCollider = default;

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, _shootRange, _itemLayerMask))
        {
            //hitPosition = hit.point;    // Ray が当たった場所
            hitCollider = hit.collider;    // Ray が当たったオブジェクト
        
            if (Input.GetMouseButtonDown(0))
            {
                if (hitCollider.tag == "Radar")
                {
                    RadarHit(hitCollider);
                }
                if(hitCollider.tag == "Mape")
                {
                    MapeHit(hitCollider);
                }
            }
        }
    }

    /// <summary>それぞれが当たった時の処理</summary>
    void RadarHit(Collider collider)
    {
        
        Debug.Log("Radarは当たった");
    }
    void MapeHit(Collider collider)
    {
        Debug.Log("Mapeは当たった");
    }
    //void DoorHit(Collider collider)
    //{
    //    Debug.Log("ドアは当たった");
    //}
}
