using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int _hungry = 50;
    private int _happy = 50;
    private int _smart = 50;
    private int _helth = 50;
    public int Hungry
    {
        set { _hungry = Mathf.Clamp(value,0,100); }
        get { return _hungry; }
    }
    public int Happy
    {
        set {_happy = Mathf.Clamp(value,0,100);}
        get { return _happy; } 
    }
    public int Smart
    {
        set { _smart = Mathf.Clamp(value, 0, 100); }
        get { return _smart; }
    }
    public int Health
    {
        set { _helth = Mathf.Clamp(value, 0, 100); }
        get { return _helth; }
    }
    public Condition PlayerCondition = Condition.Normal;

    private PlayerAnimation _playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerConditionUpdate();
        PlayerConditionMoving();
    }

    ////プレイヤーコンディションの管理
    public void PlayerConditionUpdate()
    {
        if (Health <= 0 )
        {
            Hungry = 0;
            PlayerCondition = Condition.Tired;
        }
        else if (Hungry <= 0)
        {
            PlayerCondition = Condition.Hungry;
        }
        else if (Smart <= 0)
        {
            PlayerCondition = Condition.Stupid;
        }
        else if (Happy <= 0)
        {
            PlayerCondition = Condition.Angry;
        }
        else if (Happy >= 80)
        {
            PlayerCondition = Condition.Happy;
        }
        else
        {
            PlayerCondition = Condition.Normal;
        }
    }
    //プレイヤーのコンディションに応じた動きとアニメーション
    public void PlayerConditionMoving()
    {
        if (PlayerCondition == Condition.Normal)
        {
            _playerAnimation.NormalSprite();
            //ランダムウォーク(DoTween)
            //他のプレイヤーに近づいて話しかける

        }
        else if (PlayerCondition == Condition.Tired)
        {
            _playerAnimation.TiredSprite();
            //座り込むアニメーション
        }
        else if (PlayerCondition == Condition.Hungry)
        {
            _playerAnimation.HungrySprite();
            //ランダムでうなだれるアニメーション
        }
        else if (PlayerCondition == Condition.Stupid)
        {
            _playerAnimation.StupidSprite();
            //顔があほになるアニメーション
        }
        else if (PlayerCondition == Condition.Angry)
        {
            _playerAnimation.AngrySprite();
            //怒りのアニメーション
        }
        else if(PlayerCondition == Condition.Happy)
        {
            _playerAnimation.HappySprite();
            //Happyのアニメーション
        }
    }
}
