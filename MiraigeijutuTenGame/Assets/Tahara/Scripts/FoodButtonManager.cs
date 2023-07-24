using UnityEngine;
using UnityEngine.UI;
using static LevelManager;

public class FoodButtonManager : MonoBehaviour
{
    [SerializeField] Button[] _riceButton;
    [SerializeField] GameObject _rice;
    int _buttonNumber = 0;
    int _riceUnlock;
    //�k���N�̃X�N���v�g����n�[�g���擾
    [SerializeField] AddHeart _addHeart;
    void Start()
    {
        
    }
    private void Update()
    {
        ButtonColor();
    }
    //�{�^���������ꂽ���Ƃ̏���
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

        GameObject rice_obj = Instantiate(_rice, new Vector3(0, 0, 0),Quaternion.identity);
        Destroy(rice_obj, 3f);
        foreach(var player in HomeCharactorList)
        {
            player.Hungry += 30;
            Debug.Log(player.Hungry + "���Ȃ��̐��l");
        }
        _addHeart._heart -= 50;//�n�[�g��������L�ڂ͂��Ă��Ȃ��̂ŗv����
        Debug.Log(_addHeart._heart);
    }
    public void ChocoButton()
    {
        foreach (var player in HomeCharactorList)
        {
            player.Happy += 30;
        }
        _addHeart._heart -= 1000;
    }
    public void PizaButtonUnlock()
    {
        //���M�{�^���F�������������@�n�[�g����
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += 60;
        }
        _addHeart._heart -= 5000;
    }
    public void IceButtonUnlock()
    {
        foreach (var player in HomeCharactorList)
        {
            player.Happy += 60;
            player.Hungry += 30;
        }
        //�������񁪒��@���Ȃ������@�n�[�g����
        _addHeart._heart -= 5000;
        
    }
    public void SaladaButtonUnlock()
    {
        //�m�[�g�p�\�R���{�^���F������������ �������񁫏� �n�[�g����
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += 60;
            player.Happy -= 30;
        }
    }
    public void KathuCurryButtonUnlock()
    {
        foreach (var player in HomeCharactorList)
        {
            player.Hungry += 90;
            player.Happy += 60;
        }
        //���Ȃ�����@�������񁪒��@�n�[�g����
        _addHeart._heart -= 10000;
    }
    public void CakeButtonUnlock()
    {
        foreach (var player in HomeCharactorList)
        {
            player.Happy += 90;
            player.Hungry += 60;
        }
        //�������񁪑�@���Ȃ������@�n�[�g����
        _addHeart._heart -= 10000;
    }
    public void NutoritionFoodButtonUnlock()
    {
        foreach (var player in HomeCharactorList)
        {
            player.Familiarity += 90;
            player.Happy -= 30;
        }
        //������������@�������񁫏��@�n�[�g����
    }
}
