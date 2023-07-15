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
        //スクリプトを取得して格納
        _addHeart = new AddHeart();
        //_addHeart = GetComponent<AddHeart>();
        _heart = _addHeart._heart;
        _riceUnlock = PlayerPrefs.GetInt("ButtonUnlock", 8);
        Unlock();
    }

    void Unlock()
    {
        //順番にボタンを開放してもらうため、解放されているボタン数を保存
        
        for (int i = 0; i < _riceButton.Length; i++)
        {
            if (i < _riceUnlock && _heart > 50)
            {
                Debug.Log("実行");
                _riceButton[i].interactable = true;
                _heart -= 500;
            }
            else
            {
                _riceButton[i].interactable = false;
            }
        }

    }
    //保存してあるButtonUnlockの値を取得し、次のボタン番号と比較。値が大きい場合は保存している
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