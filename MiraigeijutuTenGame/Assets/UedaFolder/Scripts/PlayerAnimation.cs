using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Tooltip("�W���̖�0,�Ί�̖�:1,������:2,���قȖ�:3")]
    [SerializeField]
    GameObject[] _eyeSprites;
    [Tooltip("�W���̌�0,�J������:1,�{������:2,���قȌ�:3")]
    [SerializeField]
    GameObject[] _mouseSprites;
    private void ResetSprite()
    {
        for (int i = 0; i < _eyeSprites.Length; i++)
        {
            _eyeSprites[i].SetActive(false);
            _mouseSprites[i].SetActive(false);
        }
    }
    public void NormalSprite()
    {
        ResetSprite();
        _eyeSprites[0].SetActive(true);
        _mouseSprites[0].SetActive(true);
    }
    //�{���ԂɂȂ����Ƃ���x�����Ăяo�����AUniRx���g������
    public void AngrySprite()
    {
        ResetSprite();
        _eyeSprites[0].SetActive(true);
        _mouseSprites[2].SetActive(true);
    }
    public void HappySprite()
    {
        ResetSprite();
        _eyeSprites[1].SetActive(true);
        _mouseSprites[1].SetActive(true);
    }

    public void HungrySprite()
    {
        ResetSprite();
        _eyeSprites[2].SetActive(true);
        _mouseSprites[1].SetActive(true);
    }
    public void TiredSprite()
    {
        ResetSprite();
        _eyeSprites[2].SetActive(true);
        _mouseSprites[0].SetActive(true);
    }
    public void StupidSprite() {
        ResetSprite();
        _eyeSprites[3].SetActive(true);
        _mouseSprites[3].SetActive(true);
    }


}
