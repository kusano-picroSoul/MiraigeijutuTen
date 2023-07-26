using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StrokingController : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    Animator _jump;
    HeartShop _heartShop;
    AddHeart _add;
    PlayerStatus _status;
    [SerializeField] int _timer;
    private void Start()
    {
        _jump = GetComponent<Animator>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _heartShop = GameObject.Find("System").GetComponent<HeartShop>();
        _add = GameObject.Find("Canvas/Heart").GetComponent<AddHeart>();
        _status = GetComponent<PlayerStatus>();
    }
    private void OnMouseDrag()
    {
        _playerAnimation.HappySprite();
        _timer++;
        if (_timer % 30 == 0)
        {
            _status.Happy += 1;
            _status.Familiarity += 1;
            _add._heart += _heartShop._strokingAddHeart;
        }
    }
    private void OnMouseUp()
    {
        _playerAnimation.NormalSprite();
        _status.PlayerConditionUpdate();
        _jump.Play("JumpMotion");
        _timer = 0;
    }

}
