using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 0.1秒ごとに「実装(解放)されているキャラ数*場に出ているキャラ*絆パワーレベル」でハートを増やす
/// </summary>
public class AddHeart : MonoBehaviour
{
    [SerializeField] Text _heartUI;
    [SerializeField] HeartShop _heartShop;
    /// <summary> ハートの総数 </summary>
    public float _heart = 50;

    float _timer;
    //0.1秒間に一回増やす
    float _addHeartTime = 0.1f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_addHeartTime < _timer)
        {
            //実装キャラの数×場にいるキャラの数×きずなパワー
            _heart += LevelManager.AllCharactorList.Count * LevelManager.HomeCharactorList.Count * 
                _heartShop._friendPowerLevel;
            _heartUI.text = _heart.ToString();
            _timer = 0;
        }
    }
}
