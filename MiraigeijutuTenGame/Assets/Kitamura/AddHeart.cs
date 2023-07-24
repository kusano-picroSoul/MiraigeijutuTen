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

    //0.1�b�Ԃő�����n�[�g�̐�
    public float _addHearts;

    float _timer;
    
    //0.1�b�ԂɈ�񑝂₷
    float _addHeartTime = 0.1f;
    
    //��ɂ���R���f�B�V�������m�[�}���ȃL�����̐�
    int _normalConditionPlayerCount = 0;
    
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

            //�����L�����̐��~��ɂ���R���f�B�V�������m�[�}���ȃL�����̐�
            _addHearts = LevelManager.AllCharactorList.Count * _normalConditionPlayerCount *
                //�~��ɂ���L�����̃X�e�[�^�X�̍��v�l�~0.01
                ((_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue) * 0.01f) * 
                //�~�����ȃp���[���x��
                _heartShop._friendPowerLevel *
                //�~�{��
                0.1f;

            //�n�[�g�̑���+0.1�b�Ԃő�����n�[�g�̗�
            _heart += _addHearts;
            int IntHeart = (int)_heart;
            _heartUI.text = IntHeart.ToString();

            Debug.Log(LevelManager.AllCharactorList.Count + " " + _normalConditionPlayerCount + " " +
                (_hungryTotalValue + _happyTotalValue + _smartTotalValue + _familiarityTotalValue)*0.01f);

            //���l�̏�����
            _normalConditionPlayerCount = 0;
            _hungryTotalValue = 0;
            _happyTotalValue = 0;
            _smartTotalValue = 0;
            _familiarityTotalValue = 0;

            //�^�C�}�[�̏�����
            _timer = 0;
        }
    }
}
