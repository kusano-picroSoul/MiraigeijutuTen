using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartShop : MonoBehaviour
{
    /// <summary>TEXTにコンポーネントとして付いてる</summary>
    [SerializeField] AddHeart _addHeart;

    [SerializeField] Text _addHeartSeconds;
    [SerializeField] Text _touchAddHeart;
    [SerializeField] Text _heartCost0;
    [SerializeField] Text _heartCost1;

    /// <summary> きずなパワーのレベル　※秒間きずなパワーレベル×１０のハートをゲット </summary>
    public int _friendPowerLevel = 1;
    /// <summary> あまえオーラのレベル　※場にいるプレイヤーをタッチするとあまえオーラレベルに応じてハートをゲット </summary>
    public int _lovePowerLevel = 1;

    //コスト倍率（仮）
    int _level = 500;

    public int _strokingAddHeart = 10000;

    void Start()
    {
        _heartCost0.text = "cost " + (_level * _friendPowerLevel).ToString();
        _addHeartSeconds.text = (_addHeart._addHearts * 10).ToString("F0") + "/s";
        _heartCost1.text = "cost " + (_level * _lovePowerLevel).ToString();
        _touchAddHeart.text = "+" + (_strokingAddHeart).ToString();
    }

    void Update()
    {
        _addHeartSeconds.text = (_addHeart._addHearts * 10).ToString("F0") + "/s";
    }
    /// <summary> shopのきずなパワーボタンで呼び出し </summary>
    public void FriendPowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            //マイナスするコスト
            float cost;
            cost = _level * _friendPowerLevel;
            if (_addHeart._heart > cost)
            {
                _addHeart._heart -= cost;
                _friendPowerLevel += 1;
                _addHeartSeconds.text = (_addHeart._addHearts * 10).ToString("F0") + "/s";
                //コストが1000を超えたらkで表示するように
                if (1000 < _level * _friendPowerLevel)
                {
                    float kilo = (float)(_level * _friendPowerLevel)/1000;
                    _heartCost0.text = "cost " + kilo + "k";
                }
                else
                {
                    _heartCost0.text = "cost " + (_level * _friendPowerLevel).ToString();
                }
            }
        }
    }
    /// <summary> shopのあまえオーラボタンで呼び出し </summary>
    public void LovePowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            //マイナスするコスト
            float cost;
            cost = _level * _lovePowerLevel;
            if (_addHeart._heart > cost)
            {
                _addHeart._heart -= cost;
                _lovePowerLevel += 1;
                _strokingAddHeart = _lovePowerLevel * 10000;
                _touchAddHeart.text = "+" +(_strokingAddHeart).ToString();
                if (1000 < _level * _lovePowerLevel)
                {
                    float kilo = (float)(_level * _lovePowerLevel) / 1000;
                    _heartCost1.text = "cost " + kilo + "k";
                }
                else
                {
                    _heartCost1.text = "cost " + (_level * _lovePowerLevel).ToString();
                }
            }
        }
    }
}
