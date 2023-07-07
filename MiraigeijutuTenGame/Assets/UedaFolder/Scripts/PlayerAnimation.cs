using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
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
    [SerializeField] float _moveRange;
    [SerializeField] float _rotateDuration;
    private void Start()
    {
        MoveAnimation();
    }
    private async void MoveAnimation()
    {
        while (true)
        {
            await RandomWalk();
            await UniTask.Delay(3000);
            print("呼ばれた");
        }
    }
    public async UniTask RandomWalk()
    {
        float moveTime = 3f;
        Vector3 randomPosition = new Vector3(Random.Range(-_moveRange, _moveRange), Random.Range(-_moveRange, _moveRange), 0);
        print($"呼ばれた2{randomPosition}");
        transform.DOMove(randomPosition, moveTime);
        WalkingAnimation(moveTime);
        await UniTask.Delay((int)( moveTime* 1000));
        return;
    }
    public async void WalkingAnimation(float moveTime)
    {
        float startTime = Time.time;
        int Count = Random.Range(0,2);
        while(true)
        {
            if(Time.time - startTime < moveTime)
            {
                if(Count % 2 == 0)
                {
                    transform.DOLocalRotate(new Vector3(0, 0, 10), _rotateDuration);
                    await UniTask.Delay((int)(_rotateDuration * 1000));
                }
                else
                {
                    transform.DOLocalRotate(new Vector3(0, 0, -10), _rotateDuration);
                    await UniTask.Delay((int)(_rotateDuration * 1000));
                }
                Count ++ ;
            }
            else
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), _rotateDuration);
                break;
            }
            print ("呼ばれた3");
        }
    }


}
