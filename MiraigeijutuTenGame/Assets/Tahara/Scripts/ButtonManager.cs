using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static LevelManager;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] _riceButton;
    AddHeart _addHeart;
    float _heart;
    int _riceUnlock;
    FoodFlags _boolFoodList = FoodFlags.Rice | FoodFlags.Choco | FoodFlags.Protain | FoodFlags.PizaAndCola | FoodFlags.Ice | FoodFlags.Salada
        | FoodFlags.KathuCurry | FoodFlags.Cake | FoodFlags.NutoritionFood;

    void Start()
    {
        //�X�N���v�g���擾���Ċi�[
        _addHeart = new AddHeart();
        //_addHeart = GetComponent<AddHeart>();
        _heart = _addHeart._heart;
        _riceUnlock = PlayerPrefs.GetInt("ButtonUnlock", 8);
        Unlock();
    }

    void Unlock()
    {
        //���ԂɃ{�^�����J�����Ă��炤���߁A�������Ă���{�^������ۑ�
        
        for (int i = 0; i < _riceButton.Length; i++)
        {
            if (i < _riceUnlock && _heart > 50)
            {
                Debug.Log("���s");
                _riceButton[i].interactable = true;
                _heart -= 500;
            }
            else
            {
                _riceButton[i].interactable = false;
            }
        }

    }
    //�ۑ����Ă���ButtonUnlock�̒l���擾���A���̃{�^���ԍ��Ɣ�r�B�l���傫���ꍇ�͕ۑ����Ă���
    public void NewRiceButton()
    {
        int _Unlock = PlayerPrefs.GetInt("ButtonUnlock");
        int NextButton = SceneManager.GetActiveScene().buildIndex + 1;
        if (NextButton < 5)
        {
            if (_Unlock < NextButton)
            {
                PlayerPrefs.SetInt("ButtonUnlock", NextButton);
            }
        }
    }
}