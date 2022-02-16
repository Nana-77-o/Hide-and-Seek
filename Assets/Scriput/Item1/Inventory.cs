using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform _content;
    [SerializeField] GameObject _imagePrefab;
    /// <summary>画像</summary>
    [SerializeField] GameObject _image;
    /// <summary>アイテム獲得のフラグ</summary>
    static public bool _itemeGetFlag = false;
    List<Goods> inventory = new List<Goods>();

    static Inventory instance;
    public static Inventory GetInstance()
    {
        return instance;
    }
    public void Start()
    {
        _image.SetActive(false);
    }

    // アイテムを取得するメソッド
    public void Obtain(Obtainable item)
    {
        // アイテムの存在を確認
        if (ItemManager.GetInstance().HasItem(item.GetItemName()))
        {
            //GameObject goodsObj = Instantiate(_imagePrefab, _content); // Imageインスタンスを作る
            //Goods goods = goodsObj.GetComponent<Goods>(); // スクリプトを取得
            _image.SetActive(true); // 画像などを設定
            //inventory.Add(goods); // リストに入れる
            Debug.Log(item.GetItemName() + "を取得した");
            _itemeGetFlag = true;
        }
        else
        {
            Debug.Log("アイテム名が無効");
        }
    }
    private void Awake()
    {
        instance = this;
    }

}
