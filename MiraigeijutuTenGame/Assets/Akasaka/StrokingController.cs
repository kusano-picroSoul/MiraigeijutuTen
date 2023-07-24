using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StrokingController : PlayerPresenter
{
    private PlayerAnimation _playerAnimation;
    private Animator _JunpMotion;
    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        
    }
    private void OnMouseDrag()
    {
        _playerAnimation.HappySprite();
    }

    private void OnMouseUp()
    {
        _JunpMotion = GetComponent<Animator>();
        _JunpMotion.SetBool("JumpMotion", true);
    }

}
