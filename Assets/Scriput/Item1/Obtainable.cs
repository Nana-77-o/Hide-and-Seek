using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Obtainable
{
    [SerializeField] string itemName;
    [SerializeField] GameObject gameObject;

    internal void Obtain(GameObject item)
    {
        gameObject = item;
        Inventory.GetInstance().Obtain(this);

    }

    internal string GetItemName()
    {
        return itemName;
    }

    internal GameObject GetGameObject()
    {
        return gameObject;
    }
}
