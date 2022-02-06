using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
	public enum KindOfItem
	{
		Weapon,
		UseItem
	}
	/// <summary>アイテムの種類</summary>
	[SerializeField] KindOfItem kindOfItem;
	/// <summary>アイテムのアイコン</summary>
	[SerializeField] Sprite icon;
	/// <summary>アイテムの名前</summary>
	[SerializeField] string itemName;
	/// <summary>アイテムの情報</summary>
	[SerializeField] string information;

	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}

	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemName;
	}

	public string GetInformation()
	{
		return information;
	}
}
