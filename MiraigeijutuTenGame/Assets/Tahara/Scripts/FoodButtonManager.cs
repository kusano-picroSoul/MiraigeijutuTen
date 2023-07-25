using UnityEngine;
using UnityEngine.UI;
using static LevelManager;

public class FoodButtonManager : MonoBehaviour
{
    [SerializeField] Button[] _riceButton;
    [SerializeField] GameObject[] _riceprefabs;
    int _buttonNumber = 0;
    int _riceUnlock;
    //ステータス管理用変数
    int _small = 30;
    int _medium = 60;
    int _large = 90;
    //北村君のスクリプトからハートを取得
    [SerializeField] AddHeart _addHeart;
    void Start()
    {
        
    }
    private void Update()
    {
        ButtonColor();
    }
    //ボタンが押されたごとの処理
    public void ButtonColor()
    {
        foreach (var button in _riceButton)
        { 
                button.interactable = false;
        }
        if (_addHeart._heart > 50)
        {
            _riceButton[0].interactable = true;
            _riceButton[1].interactable = true;
            _riceButton[2].interactable = true;
        }
        if (_addHeart._heart > 150)
        {
            _riceButton[3].interactable = true;
            _riceButton[4].interactable = true;
            _riceButton[5].interactable = true;
        }
        if (_addHeart._heart > 300)
        {
            _riceButton[6].interactable = true;
            _riceButton[7].interactable = true;
            _riceButton[8].interactable = true;
        }
    }
    public void RiceButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[0], new Vector3(0, 0, 0),Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach(var player in HomeCharactorList)
        {
            player.Hungry += _small;
            Debug.Log(player.Hungry + "おなかの数値");
        }
        _addHeart._heart -= 50;//ハートが増える記載はしていないので要注意
        //Debug.Log(_addHeart._heart);
    }
    public void ChocoButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach (var player in HomeCharactorList)
        {
            player.Happy += _small;
            Debug.Log(player.Happy);
        }
        _addHeart._heart -= 50;
        
    }
    public void StudyButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[2], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        //鉛筆ボタン：かしこさ↑小　ハート↑小
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += _medium;
        }
        _addHeart._heart -= 50;
    }
    public void PizaButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[3], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        //おなか↑中　ごきげん↑小　ハート↑中 
        foreach (var player in HomeCharactorList)
        {
            player.Hungry += _medium;
            player.Happy += _small;
        }
        _addHeart._heart -= 50;
    }
    public void IceButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[4], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach (var player in HomeCharactorList)
        {
            player.Happy += _medium;
            player.Hungry += _small;
        }
        //ごきげん↑中　おなか↑小　ハート↑中
        _addHeart._heart -= 50;
        
    }
    public void PCButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[5], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        //ノートパソコンボタン：かしこさ↑中 ごきげん↓小 ハート↑中
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += _medium;
            player.Happy -= _small;
        }
        _addHeart._heart -= 50;
    }
    public void KathuCurryButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[6], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach (var player in HomeCharactorList)
        {
            player.Hungry += _large;
            player.Happy += _medium;
        }
        //おなか↑大　ごきげん↑中　ハート↑大
        _addHeart._heart -= 10000;
    }
    public void CakeButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[7], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach (var player in HomeCharactorList)
        {
            player.Happy += _large;
            player.Hungry += _medium;
        }
        //ごきげん↑大　おなか↑中　ハート↑大
        _addHeart._heart -= 10000;
    }
    public void NutoritionFoodButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[8], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += _large;
            player.Happy -= _small;
        }
        //かしこさ↑大　ごきげん↓小　ハート↑大
    }
}
