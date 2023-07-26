using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static LevelManager;

public class FoodButtonManager : MonoBehaviour
{
    [SerializeField] Button[] _riceButton;
    [SerializeField] GameObject[] _riceprefabs;
    int _buttonNumber = 0;
    int _riceUnlock;
    //�X�e�[�^�X�Ǘ��p�ϐ�
    int _small = 30;
    int _medium = 60;
    int _large = 90;
    [SerializeField] int _timer = 0;
    [SerializeField] List<Transform>  ricePoint = new List<Transform>();
    //�k���N�̃X�N���v�g����n�[�g���擾
    [SerializeField] AddHeart _addHeart;
    void Start()
    {
        
    }
    private void Update()
    {
        ButtonColor();
        if (_timer > 300) _timer = 0;
        else if (_timer != 0) _timer++;
    }
    //�{�^���������ꂽ���Ƃ̏���
    public void ButtonColor()
    {
        if (_addHeart._heart > 50 && _timer == 0)
        {
            _riceButton[0].interactable = true;
            _riceButton[1].interactable = true;
            _riceButton[2].interactable = true;
        }
        else
        {
            _riceButton[0].interactable = false;
            _riceButton[1].interactable = false;
            _riceButton[2].interactable = false;
        }
        if (_addHeart._heart > 150 && _timer == 0)
        {
            _riceButton[3].interactable = true;
            _riceButton[4].interactable = true;
            _riceButton[5].interactable = true;
        }
        else
        {
            _riceButton[3].interactable = false;
            _riceButton[4].interactable = false;
            _riceButton[5].interactable = false;
        }
        if (_addHeart._heart > 300 && _timer == 0)
        {
            _riceButton[6].interactable = true;
            _riceButton[7].interactable = true;
            _riceButton[8].interactable = true;
        }
        else
        {
            _riceButton[6].interactable = false;
            _riceButton[7].interactable = false;
            _riceButton[8].interactable = false;
        }
    }
    public void HomeCharactorsFoodAnimationControll(List<Transform> foodPoint, int mode)
    {
        for (int i = 0; i < HomeCharactorList.Count; i++)
        {
            if (mode == 0 && HomeCharactorList[i].Hungry < 1000) FoodAnimationControll(i, foodPoint[i]);
            else if (mode == 1 && HomeCharactorList[i].Happy > 0) FoodAnimationControll(i, foodPoint[i]);
        }
        _timer++;
    }
    public async void FoodAnimationControll(int index , Transform point)
    {
        HomeCharactorList[index].gameObject.GetComponent<PlayerAnimation>().StopAmnimation();
        await HomeCharactorList[index].transform.DOMove(point.position, 1f)
                .AsyncWaitForCompletion();
        LevelManager.Instance.ChangeSortingLayer("Food");
        await UniTask.Delay(5000);
        HomeCharactorList[index].gameObject.GetComponent<PlayerAnimation>().ActiveAnimation();
    }
    public void RiceButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[0], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            player.Hungry += _small;
        }
        _addHeart._heart -= 50;//�n�[�g��������L�ڂ͂��Ă��Ȃ��̂ŗv����
        HomeCharactorsFoodAnimationControll(ricePoint, 0);
    }
    public void ChocoButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            if (player.Hungry < 1000) player.Happy += _small;
            Debug.Log(player.Happy);
        }
        _addHeart._heart -= 50;
        HomeCharactorsFoodAnimationControll(ricePoint, 0);
    }
    public void StudyButton()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[2], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        //���M�{�^���F�������������@�n�[�g����
        foreach (var player in HomeCharactorList)
        {
            if (player.Happy > 0) player.Familiarity += _medium;
        }
        _addHeart._heart -= 50;
        HomeCharactorsFoodAnimationControll(ricePoint, 1);
    }
    public void PizaButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[3], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        //���Ȃ������@�������񁪏��@�n�[�g���� 
        foreach (var player in HomeCharactorList)
        {
            if (player.Hungry < 1000)
            {
                player.Hungry += _medium;
                player.Happy += _small;
            }
        }
        _addHeart._heart -= 50;
        HomeCharactorsFoodAnimationControll(ricePoint, 0);
    }
    public void IceButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[4], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            if (player.Hungry < 1000)
            {
                player.Happy += _medium;
                player.Hungry += _small;
            }
        }
        //�������񁪒��@���Ȃ������@�n�[�g����
        _addHeart._heart -= 50;
        HomeCharactorsFoodAnimationControll(ricePoint, 0);

    }
    public void PCButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[5], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        //�m�[�g�p�\�R���{�^���F������������ �������񁫏� �n�[�g����
        foreach (var player in HomeCharactorList)
        {
            if (player.Happy > 0)
            {
                player.Familiarity += _medium;
                player.Happy -= _small;
            }
        }
        _addHeart._heart -= 50;
        HomeCharactorsFoodAnimationControll(ricePoint, 1);
    }
    public void KathuCurryButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[6], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            if (player.Hungry < 1000)
            {
                player.Hungry += _large;
                player.Happy += _medium;
            }
        }
        //���Ȃ�����@�������񁪒��@�n�[�g����
        _addHeart._heart -= 10000;
        HomeCharactorsFoodAnimationControll(ricePoint, 0);
    }
    public void CakeButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[7], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            if (player.Hungry < 1000)
            {
                player.Happy += _large;
                player.Hungry += _medium;
            }
        }
        //�������񁪑�@���Ȃ������@�n�[�g����
        _addHeart._heart -= 10000;
        HomeCharactorsFoodAnimationControll(ricePoint, 0);
    }
    public void NutoritionFoodButtonUnlock()
    {
        GameObject rice_obj = Instantiate(_riceprefabs[8], new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(rice_obj, 5f);
        foreach (var player in HomeCharactorList)
        {
            if (player.Happy > 0)
            {
                player.Familiarity += _large;
                player.Happy -= _small;
            }
        }
        //������������@�������񁫏��@�n�[�g����
        HomeCharactorsFoodAnimationControll(ricePoint, 1);
    }
}
