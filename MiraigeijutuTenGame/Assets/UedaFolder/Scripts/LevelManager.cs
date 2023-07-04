using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    /// <summary>
    /// Start�ȍ~�ŎQ�Ɖ\�BgetOnly
    /// </summary>
    public static LevelManager Instance => instance;
    //���݂̂��ׂẴL�����N�^�[���X�g
    public static List<PlayerStatus> AllCharactorList = new List<PlayerStatus>();
    //���݂̑I������Ă���L�����N�^�[
    public static List<PlayerStatus> HomeCharactorList = new List<PlayerStatus>();
    /// <summary>
    /// �r�b�g�t���O�^�̃t�[�h���X�g(enum)
    /// </summary>
    public static FoodFlags BoolFoodList;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        int i=0;
        while(Resources.Load<PlayerStatus>("PlayerPrefabs/Player" + i) ? true : false)
        {
            AllCharactorList.Add(Instantiate(
                Resources.Load<PlayerStatus>("PlayerPrefabs/Player" + i)
                ,transform.position + new Vector3(i ,0 , 0)
                ,Quaternion.identity));
            i++;
        }
        
    }
    void Update()
    {
        //LevelManager.AllCharactorList[0].gameObject.SetActive(false);
    }
    [Flags]
    public enum FoodFlags
    {
        Rice = 0 << 0,
        Choco = 0 << 1,
        Protain = 0 << 2,
        PizaAndCola = 0 << 3,
        Ice = 0 << 4,
        Salada = 0 << 5,
        KathuCurry = 0 << 6,
        Cake = 0 << 7,
        NutoritionFood = 0 << 8,
    }
}
