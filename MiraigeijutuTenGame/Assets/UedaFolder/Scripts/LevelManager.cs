using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    /// <summary>
    /// Start以降で参照可能。getOnly
    /// </summary>
    public static LevelManager Instance => instance;
    //現在のすべてのキャラクターリスト
    public static List<PlayerStatus> AllCharactorList = new List<PlayerStatus>();
    //現在の選択されているキャラクター
    public static List<PlayerStatus> HomeCharactorList = new List<PlayerStatus>();
    /// <summary>
    /// ビットフラグ型のフードリスト(enum)
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
