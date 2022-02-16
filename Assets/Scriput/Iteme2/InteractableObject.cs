using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    [Header("必要なコンポーネントを登録")]
    /// <summary></summary>
    [SerializeField] GameObject lookUpCanvas = null;
    /// <summary></summary>
    //[SerializeField]Text lookUpText = null;
    /// <summary></summary>
    [SerializeField]SimpleInventory inventory = null;

    [Header("オブジェクトを調べた時のメッセージを記入")]
    //[SerializeField, Multiline]string message = "";

    [Header("アイテムを取得できる場合のみ設定")]
    /// <summary>アイテム取得のフラグ</summary>
    [SerializeField, Space] bool getItem = false;
    /// <summary>アイテムの名前</summary>
    [SerializeField] string getItemName = "";
    
    /// <summary>アイテム取得のフラグ</summary>
    bool itemIsAcquired = false;
    static public bool itemUsed = false;
    public void LookUp()
    {
        lookUpCanvas.SetActive(true);

        if (getItem && !itemIsAcquired)
        {
            //inventory.SetItem(getItemName, true);
            itemIsAcquired = true;
        }
    }
}
