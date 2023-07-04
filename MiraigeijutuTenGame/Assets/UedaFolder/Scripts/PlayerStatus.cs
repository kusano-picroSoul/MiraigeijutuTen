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

    ////�v���C���[�R���f�B�V�����̊Ǘ�
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
    //�v���C���[�̃R���f�B�V�����ɉ����������ƃA�j���[�V����
    public void PlayerConditionMoving()
    {
        if (PlayerCondition == Condition.Normal)
        {
            _playerAnimation.NormalSprite();
            //�����_���E�H�[�N(DoTween)
            //���̃v���C���[�ɋ߂Â��Ęb��������

        }
        else if (PlayerCondition == Condition.Tired)
        {
            _playerAnimation.TiredSprite();
            //���荞�ރA�j���[�V����
        }
        else if (PlayerCondition == Condition.Hungry)
        {
            _playerAnimation.HungrySprite();
            //�����_���ł��Ȃ����A�j���[�V����
        }
        else if (PlayerCondition == Condition.Stupid)
        {
            _playerAnimation.StupidSprite();
            //�炪���قɂȂ�A�j���[�V����
        }
        else if (PlayerCondition == Condition.Angry)
        {
            _playerAnimation.AngrySprite();
            //�{��̃A�j���[�V����
        }
        else if(PlayerCondition == Condition.Happy)
        {
            _playerAnimation.HappySprite();
            //Happy�̃A�j���[�V����
        }
    }
}
