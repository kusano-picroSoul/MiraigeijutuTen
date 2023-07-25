using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StrokingController : PlayerPresenter
{
    private PlayerAnimation _playerAnimation;
    Animator _jump;
    HeartShop _heartShop;
    AddHeart _add;
    int heart;
    PlayerStatus _status;
    private void Start()
    {
        _jump = GetComponent<Animator>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _heartShop = GetComponent<HeartShop>();
        _add = GetComponent<AddHeart>();
        _status = GetComponent<PlayerStatus>();
    }
    private void OnMouseDrag()
    {
        _playerAnimation.HappySprite();
    }
    private new void OnMouseUp()
    {
        _playerAnimation.NormalSprite();
        _jump.Play("JumpMotion");
        _status.Happy += 2;
        heart = _heartShop._lovePowerLevel;
        if (heart < 500)
        {
            _add._heart += 1;
        }
        else
        {
            _add._heart += 2;
        }
    }

}
