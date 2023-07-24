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
    //場にいるコンディションがノーマルなキャラの数
    int _normalConditionPlayerCount = 0;
    //Hungryの合計値
    int _hungryTotalValue;
    //Happyの合計値
    int _happyTotalValue;
    //Smartの合計値
    int _smartTotalValue;
    //Familiarityの合計値
    int _familiarityTotalValue;

    void Update()
    {
        _timer += Time.deltaTime;
        foreach (var charctor in LevelManager.HomeCharactorList)
        {
            //_normalConditionPlayerCountに場にいるコンディションがノーマルなキャラの数を入れる
            if (charctor.PlayerCondition.Value == Condition.Normal)
            {
                _normalConditionPlayerCount++;
            }
            //場にいるキャラのステータスの合計値を入れる
            _hungryTotalValue += charctor.Hungry;
            _happyTotalValue += charctor.Happy;
            _smartTotalValue += charctor.Smart;
            _familiarityTotalValue += charctor.Familiarity;
        }

        if (_addHeartTime < _timer)
        {
            //実装キャラの数×場にいるコンディションがノーマルなキャラの数
            _heart += LevelManager.AllCharactorList.Count * _normalConditionPlayerCount *
                //×場にいるキャラのステータスの合計値
                (_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue) *
                //×きずなパワーレベル
                _heartShop._friendPowerLevel;
            _heartUI.text = _heart.ToString();
            _timer = 0;
        }
    }
}
