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
    /// <summary></summary>
    [SerializeField, Space] bool getItem = false;
    /// <summary>アイテム取得のフラグ</summary>
    [SerializeField] bool itemRequired = false;
    /// <summary>アイテムの名前</summary>
    [SerializeField] string getItemName = "";
    /// <summary>アイテムを取得したときのメッセージ</summary>
    [SerializeField, Multiline]string getItemMessage = "";

    //[Header("アイテムを使う場合のみ設定")]
    ///// <summary></summary>
    //[SerializeField, Space] bool useItem = false;
    ///// <summary></summary>
    //[SerializeField] string useItemName = "";
    ///// <summary></summary>
    //[SerializeField, Multiline] string useItemMessage = "";
    ///// <summary></summary>
    //[SerializeField] bool gameClear = false;
    ///// <summary></summary>
    //[SerializeField] Button closeButton = null;
    /// <summary>アイテム取得のフラグ</summary>
    bool itemIsAcquired = false;
    bool itemUsed = false;
    public void LookUp()
    {
        lookUpCanvas.SetActive(true);
        //lookUpText.text = message;
        //if (useItem && inventory.GetItemFlag(useItemName))
        //{
        //    lookUpText.text += "\n\n" + useItemMessage;
        //    inventory.SetItem(useItemName, false);
        //    if (gameClear)
        //    {
        //        // 「閉じる」ボタンのイベントを削除して、新しくタイトルに戻るためのイベントを追加する
        //        closeButton.onClick.RemoveAllListeners();
        //       // closeButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("GameController").GetComponent<MoveSceneManager>().MoveToScene(0));
        //    }
        //    itemUsed = true;
        //}
        if (getItem && !itemIsAcquired)
        {
            //if (itemRequired && !itemUsed)
            //{
            //    return;
            //}
            //lookUpText.text += "\n\n" + getItemMessage;
            inventory.SetItem(getItemName, true);
            itemIsAcquired = true;
        }
    }
}
