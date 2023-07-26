using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.UIElements;
using Unity.VisualScripting;
/// <summary>
/// �L�����N�^�[View���Ǘ�����X�N���v�g
/// </summary>
public class PlayerAnimation : MonoBehaviour
{

    /// <summary>
    /// �R���f�B�V�����ω��ɂ��\��̕ύX
    /// </summary>
    [SerializeField]
    SpriteRenderer _eyeSpriteRenderer;
    [SerializeField]
    SpriteRenderer _mouseSpriteRenderer;
    [Tooltip("�W���̖�0,�Ί�̖�:1,������:2,���قȖ�:3")]
    [SerializeField]
    Sprite[] _eyeSprites;
    [Tooltip("�W���̌�0,�J������:1,�{������:2,���قȌ�:3")]
    [SerializeField]
    Sprite[] _mouseSprites;
    //���ׂĂ̕\������Z�b�g����B
    Vector3 _defaltSacale = Vector3.zero;
    private void Start()
    {
        _defaltSacale = transform.localScale;
    }
    private bool ResetSprite()
    {
        for (int i = 0; i < _eyeSprites.Length; i++)
        {
            if (_eyeSprites[i] == null)
            {
                //Debug.LogError("�\���������܂���");
                return false;
            }
        }
        return true;
    }
    public void NormalSprite()
    {
        if (!ResetSprite()) { return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[0];
        _mouseSpriteRenderer.sprite = _mouseSprites[0];
    }
    public void AngrySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[0];
        _mouseSpriteRenderer.sprite = _mouseSprites[2];
    }
    public void HappySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[1];
        _mouseSpriteRenderer.sprite = _mouseSprites[1];
    }
    public void HungrySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[2];
        _mouseSpriteRenderer.sprite = _mouseSprites[1];
    }
    public void TiredSprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[2];
        _mouseSpriteRenderer.sprite = _mouseSprites[0];
    }
    public void StupidSprite() {
        if(!ResetSprite()){ return; }
        _eyeSpriteRenderer.sprite = _eyeSprites[3];
        _mouseSpriteRenderer.sprite = _mouseSprites[3];
    }

    /// <summary>
    /// �v���C���[�̓����A�A�j���[�V����
    /// </summary>
    float _moveRange = 2.5f;
    float _rotateDuration = 1f;
    float _flipDuration = 0.5f;
    
    bool _isAnimation = true;
    CancellationTokenSource cts;
    CancellationToken token;
    public Vector3 randomPosition;

    private async void MoveAnimation()
    {
        while (_isAnimation)
        { 
            await RandomWalk(token).SuppressCancellationThrow();
            if (!_isAnimation) break;
            await UniTask.Delay((int)Random.Range(3f, 10f) * 1000 ,cancellationToken: token).SuppressCancellationThrow(); 
            //print("MoveAnimation");
        }
        Debug.Log("animationEND");
    }
    
    public async UniTask RandomWalk(CancellationToken token) 
    {
        float moveTime = 3f;
        randomPosition = new Vector3(Random.Range(-_moveRange, _moveRange), Random.Range(0, _moveRange), 0);
        float animationRatio =  (randomPosition - transform.position).sqrMagnitude / (2 * (_moveRange * _moveRange)) ;

        //print($"_moveRange{_moveRange * _moveRange} : randomPosition.sqrMagnitude {randomPosition.sqrMagnitude} ");
        FlipAnimation(randomPosition.x);
        LevelManager.Instance.ChangeSortingLayer(gameObject.name);
        
        WalkingAnimation(moveTime, animationRatio, token);
        await transform.DOMove(randomPosition, moveTime)
            .ToUniTask(cancellationToken: token).SuppressCancellationThrow();
        return;
    }
    public void FlipAnimation(float positionX)
    {
        if(positionX - transform.position.x < 0 )
        {
            if (transform.localScale.x < 0)
            {
                transform.DOScaleX(Mathf.Abs(transform.localScale.x), _flipDuration)
                    .ToUniTask(cancellationToken: token).SuppressCancellationThrow();
            }
        }
        else
        {
            if(transform.localScale.x > 0)
            {
                transform.DOScaleX(-Mathf.Abs(transform.localScale.x), _flipDuration)
                    .ToUniTask(cancellationToken: token).SuppressCancellationThrow();
            }
        }
    }
    public void FixFlipAnimation()
    {
        if(Mathf.Abs(transform.localScale.x) != 1f)
        {
            if (transform.localScale.x > 0)
            {
                transform.DOScaleX(_defaltSacale.x, 0.1f)
                    .ToUniTask(cancellationToken: token).SuppressCancellationThrow();
            }
            if (transform.localScale.x < 0)
            {
                transform.DOScaleX(- _defaltSacale.x, 0.1f)
                    .ToUniTask(cancellationToken: token).SuppressCancellationThrow();
            }
        }
    }
    public async void WalkingAnimation(float moveTime , float animationRatio, CancellationToken token)
    {
        float startTime = Time.time;
        int Count = Random.Range(0,2);
        while(_isAnimation)
        {
            if(Time.time - startTime < moveTime)
            {
                if(Count % 2 == 0)
                {
                    await transform.DOLocalRotate(new Vector3(0, 0, Mathf.Clamp(10 * animationRatio, 0, 10)), _rotateDuration)
                        .AsyncWaitForCompletion();
                }
                else
                {
                    await transform.DOLocalRotate(new Vector3(0, 0, Mathf.Clamp(-10 * animationRatio, -10, 0)), _rotateDuration)
                        .AsyncWaitForCompletion();
                }
                Count ++ ;
            }
            else
            {
                await transform.DOLocalRotate(new Vector3(0, 0, 0), _rotateDuration)
                    .AsyncWaitForCompletion();
                break;
            }
            //print($"WalkingAnimation{animationRatio}");
        }
    }
    public void StopAmnimation()
    {
        transform.DOKill();
        cts.Cancel();
        FixFlipAnimation();
        transform.DOLocalRotate(new Vector3(0, 0, 0), _rotateDuration);
        _isAnimation = false;
    }
    public void ActiveAnimation()
    {
        cts = new CancellationTokenSource();
        token = cts.Token;
        FixFlipAnimation();
        //token = this.GetCancellationTokenOnDestroy();
        _isAnimation = true;
        MoveAnimation();
    }


}
