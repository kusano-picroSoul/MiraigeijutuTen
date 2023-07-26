using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartShop : MonoBehaviour
{
    /// <summary>TEXT�ɃR���|�[�l���g�Ƃ��ĕt���Ă�</summary>
    [SerializeField] AddHeart _addHeart;

    [SerializeField] Text _addHeartSeconds;
    [SerializeField] Text _touchAddHeart;
    [SerializeField] Text _heartCost0;
    [SerializeField] Text _heartCost1;

    [SerializeField] Button[] _shopButton;

    /// <summary> �����ȃp���[�̃��x���@���b�Ԃ����ȃp���[���x���~�P�O�̃n�[�g���Q�b�g </summary>
    public int _friendPowerLevel = 1;
    /// <summary> ���܂��I�[���̃��x���@����ɂ���v���C���[���^�b�`����Ƃ��܂��I�[�����x���ɉ����ăn�[�g���Q�b�g </summary>
    public int _lovePowerLevel = 1;

    //�R�X�g�{���i���j
    int _level = 500;

    public int _strokingAddHeart = 10000;

    void Start()
    {
        Application.targetFrameRate = 60;
        _heartCost0.text = (_level * _friendPowerLevel).ToString();
        _addHeartSeconds.text = (_addHeart._addHearts * 10).ToString("F0") + "/s";
        _heartCost1.text = (_level * _lovePowerLevel).ToString();
        _touchAddHeart.text = (_strokingAddHeart).ToString();
    }

    void FixedUpdate()
    {
        if (1000000 < _addHeart._addHearts * 10)
        {
            int kilo = (int)(_addHeart._addHearts * 10) / 1000000;
            _addHeartSeconds.text = kilo + "m/s";
        }
        else if (1000 < _addHeart._addHearts * 10)
        {
            int kilo = (int)(_addHeart._addHearts * 10) / 1000;
            _addHeartSeconds.text = kilo + "k/s";
        }
        else
        {
            _addHeartSeconds.text = ((int)(_addHeart._addHearts * 10)).ToString() + "/s";
        }
        foreach (var button in _shopButton)
        {
            button.interactable = false;
        }
        if (_addHeart._heart > _level * _friendPowerLevel)
        {
            _shopButton[0].interactable = true;
        }
        if (_addHeart._heart > _level * _lovePowerLevel)
        {
            _shopButton[1].interactable = true;
        }
    }
    /// <summary> shop�̂����ȃp���[�{�^���ŌĂяo�� </summary>
    public void FriendPowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            //�}�C�i�X����R�X�g
            float cost;
            cost = _level * _friendPowerLevel;
            if (_addHeart._heart > cost)
            {
                _addHeart._heart -= cost;
                _friendPowerLevel += 1;
                //�R�X�g��1000�𒴂�����k�ŕ\������悤��
                if (1000000 < _level * _friendPowerLevel)
                {
                    int kilo = (int)(_level * _friendPowerLevel) / 1000000;
                    _heartCost0.text = kilo + "m";
                }
                else if (1000 < _level * _friendPowerLevel)
                {
                    int kilo = (int)(_level * _friendPowerLevel) / 1000;
                    _heartCost0.text = kilo + "k";
                }
                else
                {
                    _heartCost0.text = (_level * _friendPowerLevel).ToString();
                }
            }
        }
    }
    /// <summary> shop�̂��܂��I�[���{�^���ŌĂяo�� </summary>
    public void LovePowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            //�}�C�i�X����R�X�g
            float cost;
            cost = _level * _lovePowerLevel;
            if (_addHeart._heart > cost)
            {
                _addHeart._heart -= cost;
                _lovePowerLevel += 1;
                _strokingAddHeart = _lovePowerLevel * 100;
                if (1000000 < _level * _lovePowerLevel)
                {
                    int kilo = (int)(_level * _lovePowerLevel) / 1000000;
                    _heartCost1.text = kilo + "m";
                }
                else if (1000 < _level * _lovePowerLevel)
                {
                    int kilo = (int)(_level * _lovePowerLevel) / 1000;
                    _heartCost1.text = kilo + "k";
                }
                else
                {
                    _heartCost1.text = (_level * _lovePowerLevel).ToString();
                }
                if (1000000 < _level * _strokingAddHeart)
                {
                    int kilo = (int)(_level * _strokingAddHeart) / 1000000;
                    _touchAddHeart.text = kilo + "m";
                }
                else if (1000 < _level * _strokingAddHeart)
                {
                    int kilo = (int)(_level * _strokingAddHeart) / 1000;
                    _touchAddHeart.text = kilo + "k";
                }
                else
                {
                    _touchAddHeart.text = (_level * _strokingAddHeart).ToString();
                }
            }
        }
    }
}
