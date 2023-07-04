using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>開発者ボタンが押された時の処理をするコンポーネント/// </summary>
public class PauseScript : MonoBehaviour
{
    //　開発者表示画面を開くボタン
    [SerializeField] private GameObject _staffButton;
    //　ゲームに戻るボタン
    [SerializeField] private GameObject _restartButton;
    //　開発者を表示するパネル
    [SerializeField] private GameObject _Panel;

    /// <summary>パネルがONの時/// </summary>
    public void StopGame()
    {
        Time.timeScale = 0f;
        _staffButton.SetActive(false);
        _restartButton.SetActive(true);
        _Panel.SetActive(true);
    }
    /// <summary>パネルがOFFの時/// </summary>
    public void ReStartGame()
    {
        _staffButton.SetActive(true);
        _restartButton.SetActive(false);
        _Panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
