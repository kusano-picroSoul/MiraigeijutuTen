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

    //�v���C���[�̃R���f�B�V�����ɉ����������ƃA�j���[�V����
    public void PlayerConditionMoving(Condition playerCondition)
    {
        //Debug.Log("�Ă΂ꂽ2");
        if (playerCondition == Condition.Normal)
        {
            _playerAnimation.NormalSprite();
            //�����_���E�H�[�N(DoTween)
            //���̃v���C���[�ɋ߂Â��Ęb��������

        }
        else if (playerCondition == Condition.Tired)
        {
            _playerAnimation.TiredSprite();
            //���荞�ރA�j���[�V����
        }
        else if (playerCondition == Condition.Hungry)
        {
            _playerAnimation.HungrySprite();
            //�����_���ł��Ȃ����A�j���[�V����
        }
        else if (playerCondition == Condition.Stupid)
        {
            _playerAnimation.StupidSprite();
            //�炪���قɂȂ�A�j���[�V����
        }
        else if (playerCondition == Condition.Angry)
        {
            _playerAnimation.AngrySprite();
            //�{��̃A�j���[�V����
        }
        else if (playerCondition == Condition.Happy)
        {
            _playerAnimation.HappySprite();
            //Happy�̃A�j���[�V����
        }
    }
}
