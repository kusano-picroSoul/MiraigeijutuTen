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

    //0.1秒間で増えるハートの数
    public float _addHearts;

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
        if (_addHeartTime < _timer)
        {
            foreach (var charctor in LevelManager.HomeCharactorList)
            {
                //_normalConditionPlayerCountに、場にいるコンディションがノーマルなキャラの数を入れる
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

            //実装キャラの数×場にいるコンディションがノーマルなキャラの数
            _addHearts = LevelManager.AllCharactorList.Count * _normalConditionPlayerCount *
                //×場にいるキャラのステータスの合計値×0.01
                ((_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue) * 0.01f) * 
                //×きずなパワーレベル
                _heartShop._friendPowerLevel *
                //×倍率
                0.1f;

            //ハートの総量+0.1秒間で増えるハートの量
            _heart += _addHearts;
            int IntHeart = (int)_heart;
            _heartUI.text = IntHeart.ToString();

            Debug.Log(LevelManager.AllCharactorList.Count + " " + _normalConditionPlayerCount + " " +
                (_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue)*0.01f);

            //数値の初期化
            _normalConditionPlayerCount = 0;
            _hungryTotalValue = 0;
            _happyTotalValue = 0;
            _smartTotalValue = 0;
            _familiarityTotalValue = 0;

            //タイマーの初期化
            _timer = 0;
        }
    }
}
