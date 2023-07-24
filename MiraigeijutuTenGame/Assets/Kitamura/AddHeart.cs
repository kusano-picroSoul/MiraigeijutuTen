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

    int _normalConditionPlayerCount = 0;

    void Update()
    {
        _timer += Time.deltaTime;
        foreach (var charctor in LevelManager.HomeCharactorList)
        {
            if (charctor.PlayerCondition.Value == Condition.Normal)
            {
                _normalConditionPlayerCount++;
            }
        }
        if (_addHeartTime < _timer)
        {
            //実装キャラの数×場にいるコンディションがノーマルなキャラの数×きずなパワー
            _heart += LevelManager.AllCharactorList.Count * _normalConditionPlayerCount *
                _heartShop._friendPowerLevel;
            _heartUI.text = _heart.ToString();
            _timer = 0;
        }
    }
}
