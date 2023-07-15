using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
/// <summary>
/// �L�����N�^�[View���Ǘ�����X�N���v�g
/// </summary>
public class PlayerAnimation : MonoBehaviour
{

    /// <summary>
    /// �R���f�B�V�����ω��ɂ��\��̕ύX
    /// </summary>
    [Tooltip("�W���̖�0,�Ί�̖�:1,������:2,���قȖ�:3")]
    [SerializeField]
    GameObject[] _eyeSprites;
    [Tooltip("�W���̌�0,�J������:1,�{������:2,���قȌ�:3")]
    [SerializeField]
    GameObject[] _mouseSprites;
    //���ׂĂ̕\������Z�b�g����B
    private bool ResetSprite()
    {
        for (int i = 0; i < _eyeSprites.Length; i++)
        {
            if(_eyeSprites[i] == null )
            {
                Debug.LogError("�\���������܂���");
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
    /// �v���C���[�̓����A�A�j���[�V����
    /// </summary>
    float _moveRange = 2.5f;
    float _rotateDuration = 0.5f;
    bool _isAnimation = true;
    private void Start()
    {
        MoveAnimation();
    }
    private async void MoveAnimation()
    {
        while (_isAnimation)
        { 
            await RandomWalk();
            await UniTask.Delay((int)Random.Range(3f, 10f) * 1000);
            //print("MoveAnimation");
        }
    }
    public Vector3 randomPosition;
    public async UniTask RandomWalk()
    {
        float moveTime = 3f;
        randomPosition = new Vector3(Random.Range(-_moveRange, _moveRange), Random.Range(0, _moveRange), 0);
        float animationRatio =  (randomPosition - transform.position).sqrMagnitude / (2 * (_moveRange * _moveRange)) ;

        //print($"_moveRange{_moveRange * _moveRange} : randomPosition.sqrMagnitude {randomPosition.sqrMagnitude} ");
        LevelManager.Instance.ChangeSortingLayer(gameObject.name);
        transform.DOMove(randomPosition, moveTime);
        WalkingAnimation(moveTime , animationRatio);
        await UniTask.Delay((int)( moveTime* 1000));
        return;
    }
    public async void WalkingAnimation(float moveTime , float animationRatio)
    {
        float startTime = Time.time;
        int Count = Random.Range(0,2);
        while(_isAnimation)
        {
            if(Time.time - startTime < moveTime)
            {
                
                if(Count % 2 == 0)
                {
                    transform.DOLocalRotate(new Vector3(0, 0, Mathf.Clamp(10 * animationRatio,0,10)), _rotateDuration);
                    await UniTask.Delay((int)(_rotateDuration * 1000));
                }
                else
                {
                    transform.DOLocalRotate(new Vector3(0, 0, Mathf.Clamp(-10 * animationRatio, -10, 0)), _rotateDuration);
                    await UniTask.Delay((int)(_rotateDuration * 1000));
                }
                Count ++ ;
            }
            else
            {
                ResetCharactorRotation();
                break;
            }
            //print($"WalkingAnimation{animationRatio}");
        }
    }
    public void ResetCharactorRotation()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 0), _rotateDuration);
    }

    public void KillDoTween()
    {
        transform.DOKill();
    }
    public void OnMouseDown()
    {
        KillDoTween();
        ResetCharactorRotation();
        _isAnimation = false;
    }
    public void OnMouseUp()
    {
        _isAnimation = true;
    }
}
