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

    //場にいるコンディションがハッピーなキャラの数
    int _happyConditionPlayerCount = 0;

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
                if (charctor.PlayerCondition.Value == Condition.Happy)
                {
                    _happyConditionPlayerCount++;
                }
                //場にいるキャラのステータスの合計値を入れる
                _hungryTotalValue += charctor.Hungry;
                _happyTotalValue += charctor.Happy;
                _smartTotalValue += charctor.Smart;
                _familiarityTotalValue += charctor.Familiarity;
            }

            
            _addHearts =
                //1 + (実装キャラの数/10)
                meg(LevelManager.AllCharactorList.Count)

                //×1 + (場にいるコンディションがノーマルなキャラの数/10)
                * meg(_normalConditionPlayerCount)

                //×1 + (場にいるコンディションがハッピーなキャラの数/10)
                * meg(_happyConditionPlayerCount)

                //×1 + (場にいるキャラのステータスの合計値/100)
                * meg01(_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue)

                //×1 + (きずなパワーレベル/100)
                * meg01(_heartShop._friendPowerLevel);

            //例　_addHearts = 1.6 * 1.0 * 1.5 * 1.90 * 1.01 

            //ハートの総量+0.1秒間で増えるハートの量
            _heart += _addHearts;
            int IntHeart = (int)_heart;
            _heartUI.text = IntHeart.ToString();

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
    /// <summary>countを1.(int count)で返す </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    float meg(int count)
    {
        return 1 + (float)count / 10.0f;
    }

    float meg01(int count)
    {
        return 1 + (float)count / 100.0f;
    }

}
