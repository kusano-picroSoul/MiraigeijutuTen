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
    [Header("foods")]
    [SerializeField] bool _rice;
    [SerializeField] bool _chocolateBar;
    [SerializeField] bool _protein;
    [SerializeField] bool _pizzaAndCola;
    [SerializeField] bool _ice;
    [SerializeField] bool _saladChicken;
    [SerializeField] bool _katsuCarry;
    [SerializeField] bool _birthdayCake;
    [SerializeField] bool _vitaminFood;

    //変動する値
    //小
    float _small = 1.1f;
    //中
    float _mid = 1.2f;
    //大
    float _large = 1.3f;

    /// <summary> きずなパワーのレベル　※秒間きずなパワーレベル×１０のハートをゲット </summary>
    public int _friendPowerLevel = 1;
    /// <summary> あまえオーラのレベル　※場にいるプレイヤーをタッチするとあまえオーラレベルに応じてハートをゲット </summary>
    public int _lovePowerLevel = 1;

    //コスト倍率（仮）
    int _level = 5000;

    void Start()
    {
        _heartCost0.text = "cost " + (_level * _friendPowerLevel).ToString();
        _heartCost1.text = "cost " + (_level * _lovePowerLevel).ToString();
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
                _addHeartSeconds.text = (_addHeart._addHearts * 10).ToString() + "/s";
                _heartCost0.text = "cost " + (_level * _friendPowerLevel).ToString();
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
                _touchAddHeart.text = "+" +(_lovePowerLevel * 10).ToString();
                _heartCost1.text = "cost " + (_level * _lovePowerLevel ).ToString();
            }
        }
    }
}
