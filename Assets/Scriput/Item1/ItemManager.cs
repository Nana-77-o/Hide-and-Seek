﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	/// <summary>アイテムデータベース</summary>
	[SerializeField] ItemDataBase itemDataBase;
	/// <summary>アイテム数管理</summary>
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();
	static ItemManager instance;

	public static ItemManager GetInstance()
	{
		return instance;
	}

	void Start()
	{
		instance = this;
		for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		{
			//　アイテム数を適当に設定
			numOfItem.Add(itemDataBase.GetItemLists()[i], i);
			//　確認の為データ出力
			Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInformation());
		}
	}

	//　名前でアイテムを取得
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
	public bool HasItem(string searchName)
	{
		return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
	}
}
