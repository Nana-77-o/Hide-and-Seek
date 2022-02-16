using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] GameObject _lose;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        //targetに向かって進む
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _lose.SetActive(true);
            Cursor.visible = true;
            // カーソルを画面内で動かせる
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
