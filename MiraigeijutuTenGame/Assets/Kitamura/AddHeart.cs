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

    float _timer;
    //0.1�b�ԂɈ�񑝂₷
    float _addHeartTime = 0.1f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_addHeartTime < _timer)
        {
            //�����L�����̐��~��ɂ���L�����̐��~�����ȃp���[
            _heart += LevelManager.AllCharactorList.Count * LevelManager.HomeCharactorList.Count * 
                _heartShop._friendPowerLevel;
            _heartUI.text = _heart.ToString();
            _timer = 0;
        }
    }
}
