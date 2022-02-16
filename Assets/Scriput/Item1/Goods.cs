using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    GameObject itemObject;
    string itemName;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetUp(Obtainable item)
    {
        image = GetComponent<Image>(); // Imageコンポーネント

        this.itemName = item.GetItemName(); // アイテム名を取得

        // 画像を取得してImageコンポーネントに入れる
        image.sprite = ItemManager.GetInstance().GetItem(this.itemName).GetIcon();
        this.itemObject = item.GetGameObject(); // オブジェクトを取得
    }

}
