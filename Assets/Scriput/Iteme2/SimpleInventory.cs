using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInventory : MonoBehaviour
{
    /// <summary>アイコンのプレハブ</summary>
    [SerializeField] GameObject iconPrefab = null;
    /// <summary>アイコンのパネル</summary>
    [SerializeField] Transform iconParent = null;
    /// <summary>アイテム</summary>
    [SerializeField] InventoryItem[] items = null;
    /// <summary>アイテムを持ってるか</summary>
    static public bool[] itemFlags;
    /// <summary>アイテムのアイコン管理のディクショナリ</summary>
    Dictionary<int, GameObject> icons = new Dictionary<int, GameObject>();
    void Start()
    {
        itemFlags = new bool[items.Length];
    }

    public bool GetItemFlag(string itemName)
    {
        int index = GetItemIndexFromName(itemName);
        return itemFlags[index];
    }
    public void SetItem(string itemName, bool isOn)
    {
        int index = GetItemIndexFromName(itemName);
        if (!itemFlags[index] && isOn)
        {
            // アイテム未所持の状態で新しく入手したとき
            // 新しいアイコンを生成し、インベントリのキャンバスの子に設定
            GameObject icon = Instantiate(iconPrefab, iconParent);
            // アイコンの画像を設定
            icon.GetComponent<Image>().sprite = items[index].itemSprite;
            icons.Add(index, icon);
        }
        else if (itemFlags[index] && !isOn)
        {
            // アイテム所持中に削除するとき
            GameObject icon = icons[index];
            // アイテムのアイコンを削除
            Destroy(icon);
            // アイコンのディクショナリから対象のアイテムを削除
            icons.Remove(index);
        }
        itemFlags[index] = isOn;
    }
    int GetItemIndexFromName(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemName == itemName)
            {
                return i;
            }
        }
        Debug.LogWarning("指定されたアイテム名が間違っているか存在しません");
        return 0;
    }
}
// インベントリに登録できるアイテムを定義するためのクラス
[System.Serializable]
public class InventoryItem
{
    public string itemName = "";
    public Sprite itemSprite = null;
}
