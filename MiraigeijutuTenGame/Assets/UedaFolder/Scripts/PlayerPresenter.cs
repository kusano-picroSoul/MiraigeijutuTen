using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class PlayerPresenter : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    private PlayerAnimation _playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        //await LoadChactor();
        _playerStatus.status._hungry.Subscribe(_=> _playerStatus.PlayerConditionUpdate()).AddTo(_playerStatus.gameObject);
        _playerStatus.status._happy.Subscribe(_ => _playerStatus.PlayerConditionUpdate()).AddTo(gameObject);
        _playerStatus.status._smart.Subscribe(_ => _playerStatus.PlayerConditionUpdate()).AddTo(gameObject);
        _playerStatus.status._helth.Subscribe(_ => _playerStatus.PlayerConditionUpdate()).AddTo(gameObject);
        _playerStatus.PlayerCondition.Subscribe(playerCondition => PlayerConditionMoving(playerCondition)).AddTo(gameObject);

    }
    //async UniTask LoadChactor()
    //{
    //    while ()
    //    {

    //    }
    //    await UniTask.Delay(500);
    //}

    //プレイヤーのコンディションに応じた動きとアニメーション
    public void PlayerConditionMoving(Condition playerCondition)
    {
        //Debug.Log("呼ばれた2");
        if (playerCondition == Condition.Normal)
        {
            _playerAnimation.NormalSprite();
            //ランダムウォーク(DoTween)
            //他のプレイヤーに近づいて話しかける

        }
        else if (playerCondition == Condition.Tired)
        {
            _playerAnimation.TiredSprite();
            //座り込むアニメーション
        }
        else if (playerCondition == Condition.Hungry)
        {
            _playerAnimation.HungrySprite();
            //ランダムでうなだれるアニメーション
        }
        else if (playerCondition == Condition.Stupid)
        {
            _playerAnimation.StupidSprite();
            //顔があほになるアニメーション
        }
        else if (playerCondition == Condition.Angry)
        {
            _playerAnimation.AngrySprite();
            //怒りのアニメーション
        }
        else if (playerCondition == Condition.Happy)
        {
            _playerAnimation.HappySprite();
            //Happyのアニメーション
        }
    }
}
