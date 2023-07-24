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
    int heart;
    private void Start()
    {
        _jump = GetComponent<Animator>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _heartShop = GetComponent<HeartShop>();
    }
    private void OnMouseDrag()
    {
        _playerAnimation.HappySprite();
        heart = _heartShop._lovePowerLevel;
    }
    private new void OnMouseUp()
    {
        _playerAnimation.NormalSprite();
        _jump.Play("JumpMotion");
    }

}
