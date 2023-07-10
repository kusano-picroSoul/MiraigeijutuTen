using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartShop : MonoBehaviour
{
    [SerializeField] AddHeart _addHeart;
    [SerializeField] Text _addHeartSeconds;
    [SerializeField] Text _touchAddHeart;
    [SerializeField] Text _heartCost0;
    [SerializeField] Text _heartCost1;

    /// <summary> �����ȃp���[�̃��x���@���b�Ԃ����ȃp���[���x���~�P�O�̃n�[�g���Q�b�g </summary>
    public int _friendPowerLevel = 0;
    /// <summary> ���܂��I�[���̃��x���@����ɂ���v���C���[���^�b�`����Ƃ��܂��I�[�����x���ɉ����ăn�[�g���Q�b�g </summary>
    public int _lovePowerLevel = 0;

    //�R�X�g�{���i���j
    int _level = 50;
    /// <summary> shop�̂����ȃp���[�{�^���ŌĂяo�� </summary>
    public void FriendPowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            if (_addHeart._heart > _level * _friendPowerLevel)
            {
                _addHeart._heart -= _level * _friendPowerLevel;
                _friendPowerLevel += 1;
                _addHeartSeconds.text = (_friendPowerLevel * 10).ToString() + "/s";
                _heartCost0.text = "cost " + (_level * _friendPowerLevel).ToString();
            }
        }
    }
    /// <summary> shop�̂��܂��I�[���{�^���ŌĂяo�� </summary>
    public void LovePowerLevelUp()
    {
        if (_addHeart._heart > 0)
        {
            if (_addHeart._heart > _level * _lovePowerLevel)
            {
                _addHeart._heart -= _level * _lovePowerLevel;
                _lovePowerLevel += 1;
                _touchAddHeart.text = "+" +(_lovePowerLevel * 10).ToString();
                _heartCost1.text = "cost " + (_level * _lovePowerLevel).ToString();
            }
        }
    }
}
