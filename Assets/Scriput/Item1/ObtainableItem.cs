using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainableItem : MonoBehaviour
{
    [SerializeField] Obtainable obt; // 取得可能クラスのオブジェクト

    // アイテムに触った時
    public void Touch(GameObject sender, Vector3 point)
    {
        obt.Obtain(gameObject); // 取得メソッドを呼ぶ
    }

    public void Release(GameObject sender)
    {

    }

}
