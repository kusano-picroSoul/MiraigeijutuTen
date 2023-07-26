using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 0.1�b���ƂɁu����(���)����Ă���L������*��ɏo�Ă���L����*�J�p���[���x���v�Ńn�[�g�𑝂₷
/// </summary>
public class AddHeart : MonoBehaviour
{
    [SerializeField] Text _heartUI;
    [SerializeField] HeartShop _heartShop;
    /// <summary> �n�[�g�̑��� </summary>
    public float _heart = 50;

    /// <summary>0.1�b�Ԃő�����n�[�g�̐�</summary>
    [SerializeField] public int _addHearts;

    float _timer;

    //0.1�b�ԂɈ�񑝂₷
    [SerializeField] float _addHeartTime = 0.1f;
    
    //��ɂ���R���f�B�V�������m�[�}���ȃL�����̐�
    int _normalConditionPlayerCount = 0;

    //��ɂ���R���f�B�V�������n�b�s�[�ȃL�����̐�
    int _happyConditionPlayerCount = 0;

    //Hungry�̍��v�l
    int _hungryTotalValue;
    
    //Happy�̍��v�l
    int _happyTotalValue;
    
    //Smart�̍��v�l
    int _smartTotalValue;
    
    //Familiarity�̍��v�l
    int _familiarityTotalValue;

    void Update()
    {   
        _timer += Time.deltaTime;
        if (_addHeartTime < _timer)
        {
            foreach (var charctor in LevelManager.HomeCharactorList)
            {
                //_normalConditionPlayerCount�ɁA��ɂ���R���f�B�V�������m�[�}���ȃL�����̐�������
                if (charctor.PlayerCondition.Value == Condition.Normal)
                {
                    _normalConditionPlayerCount++;
                }
                //��ɂ���L�����̃X�e�[�^�X�̍��v�l������
                _hungryTotalValue += charctor.Hungry;
                _happyTotalValue += charctor.Happy;
                _smartTotalValue += charctor.Smart;
                _familiarityTotalValue += charctor.Familiarity;
            }

            _addHearts =
                //1 + (�����L�����̐�/10)
                (LevelManager.AllCharactorList.Count / 5)

                //�~1 + (��ɂ���R���f�B�V�������m�[�}���ȃL�����̐�/10)
                * _normalConditionPlayerCount

                //�~1 + (��ɂ���L�����̃X�e�[�^�X�̍��v�l/100)
                * ((_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue + 1) / 750)

                //�~1 + (�����ȃp���[���x��/100)
                * _heartShop._friendPowerLevel;

            //��@_addHearts = 1.6 * 1.0 * 1.5 * 1.90 * 1.01 

            //�n�[�g�̑���+=0.1�b�Ԃő�����n�[�g�̗�
            _heart += _addHearts;

            //���l�̏�����
            _normalConditionPlayerCount = 0;
            _hungryTotalValue = 0;
            _happyTotalValue = 0;
            _smartTotalValue = 0;
            _familiarityTotalValue = 0;

            //�^�C�}�[�̏�����
            _timer = 0;
        }
        int IntHeart = (int)_heart;
        _heartUI.text = IntHeart.ToString();
    }
    /// <summary>count��1.(int count)�ŕԂ� </summary>
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
