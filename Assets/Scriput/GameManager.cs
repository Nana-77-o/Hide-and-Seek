using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>タイマーのテキスト</summary>
    [SerializeField] Text _timerText;
    /// <summary>タイマー</summary>
    [SerializeField] float _timer;
    /// <summary>逃げるほうが勝った時のパーテーション</summary>
    [SerializeField] GameObject _hideWin;

    void Start()
    {
       
    }

    void Update()
    {
        //ItemLayer();
        _timer -= Time.deltaTime;
        _timerText.text = _timer.ToString("00");
        if(_timer < 0)
        {
            HideWin();
            _timerText.gameObject.SetActive(false);
        }
    }

    private void HideWin()
    {
        Cursor.visible = true;
        // カーソルを画面内で動かせる
        Cursor.lockState = CursorLockMode.Confined;
        _hideWin.SetActive(true);
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
