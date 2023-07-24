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
/// キャラクターViewを管理するスクリプト
/// </summary>
public class PlayerAnimation : MonoBehaviour
{

    /// <summary>
    /// コンディション変化による表情の変更
    /// </summary>
    [Tooltip("標準の目0,笑顔の目:1,閉じた目:2,あほな目:3")]
    [SerializeField]
    GameObject[] _eyeSprites;
    [Tooltip("標準の口0,開いた口:1,怒った口:2,あほな口:3")]
    [SerializeField]
    GameObject[] _mouseSprites;
    //すべての表情をリセットする。
    private bool ResetSprite()
    {
        for (int i = 0; i < _eyeSprites.Length; i++)
        {
            if(_eyeSprites[i] == null )
            {
                Debug.LogError("表情差分がありません");
                return false;
            }
            _eyeSprites[i]?.SetActive(false);
            _mouseSprites[i]?.SetActive(false);
        }
        return true;
    }
    public void NormalSprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSprites[0]?.SetActive(true);
        _mouseSprites[0]?.SetActive(true);
    }
    public void AngrySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSprites[0]?.SetActive(true);
        _mouseSprites[2]?.SetActive(true);
    }
    public void HappySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSprites[1]?.SetActive(true);
        _mouseSprites[1]?.SetActive(true);
    }
    public void HungrySprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSprites[2]?.SetActive(true);
        _mouseSprites[1]?.SetActive(true);
    }
    public void TiredSprite()
    {
        if(!ResetSprite()){ return; }
        _eyeSprites[2]?.SetActive(true);
        _mouseSprites[0]?.SetActive(true);
    }
    public void StupidSprite() {
        if(!ResetSprite()){ return; }
        _eyeSprites[3]?.SetActive(true);
        _mouseSprites[3]?.SetActive(true);
    }

    /// <summary>
    /// プレイヤーの動き、アニメーション
    /// </summary>
    float _moveRange = 2.5f;
    float _rotateDuration = 1f;
    float _flipDuration = 0.5f;
    Vector3 _defaltSacale = Vector3.zero;
    bool _isAnimation = true;
    CancellationTokenSource cts;
    CancellationToken token;
    public Vector3 randomPosition;
    private void Start()
    {
        _defaltSacale = transform.localScale;
        cts = new CancellationTokenSource();
        token = cts.Token;
        //token = this.GetCancellationTokenOnDestroy();
        MoveAnimation(token);
    }
    private async void MoveAnimation(CancellationToken token)
    {
        while (_isAnimation)
        { 
            await RandomWalk(token);
            await UniTask.Delay((int)Random.Range(3f, 10f) * 1000 ,cancellationToken: token); 
            //print("MoveAnimation");
        }
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
            .ToUniTask(cancellationToken: token);
        return;
    }
    public void FlipAnimation(float positionX)
    {
        if(positionX - transform.position.x < 0 )
        {
            if (transform.localScale.x < 0)
            {
                transform.DOScaleX(Mathf.Abs(transform.localScale.x), _flipDuration);
            }
        }
        else
        {
            if(transform.localScale.x > 0)
            {
                transform.DOScaleX(-Mathf.Abs(transform.localScale.x), _flipDuration);
            }
        }
    }
    public void FixFlipAnimation()
    {
        if(Mathf.Abs(transform.localScale.x) != 1f)
        {
            if (transform.localScale.x > 0)
            {
                transform.DOScaleX(_defaltSacale.x, 0.1f);
            }
            if (transform.localScale.x < 0)
            {
                transform.DOScaleX(- _defaltSacale.x, 0.1f);
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
        FixFlipAnimation();
        transform.DOLocalRotate(new Vector3(0, 0, 0), _rotateDuration);
        _isAnimation = false;
    }
    public void ActiveAnimation()
    {
        _isAnimation = true;
    }


}
