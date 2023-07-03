using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Tooltip("標準の目0,笑顔の目:1,閉じた目:2,あほな目:3")]
    [SerializeField]
    GameObject[] _eyeSprites;
    [Tooltip("標準の口0,開いた口:1,怒った口:2,あほな口:3")]
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
    //怒り状態になったとき一度だけ呼び出される、UniRxを使いたい
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
