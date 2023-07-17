using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Threading;
using UnityEngine.UIElements;
using System.Linq;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    /// <summary>
    /// Start以降で参照可能。getOnly
    /// </summary>
    public static LevelManager Instance => instance;
    //現在のすべてのキャラクターリスト
    public static List<PlayerStatus> AllCharactorList = new List<PlayerStatus>();

    private const int MAX_HOME_CHARACTOR = 5;
    //現在の選択されているキャラクター
    public static List<PlayerStatus> HomeCharactorList = new List<PlayerStatus>();
    //キャラクター表示順番を管理するリスト
    public List<SortOrderClass> SortOrderList = new List<SortOrderClass>();
    /// <summary>
    /// ビットフラグ型のフードリスト(enum)
    /// </summary>
    [Flags]
    public enum FoodFlags
    {
        Rice = 1 << 0,
        Choco = 1 << 1,
        Protain = 1 << 2,
        PizaAndCola = 1 << 3,
        Ice = 1 << 4,
        Salada = 1 << 5,
        KathuCurry = 1 << 6,
        Cake = 1 << 7,
        NutoritionFood = 1 << 8,
    }
    public static FoodFlags BoolFoodList;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {   
        int i = 0;
        while(Resources.Load<GameObject>("PlayerPrefabs/Player" + i) ? true : false)
        {
            var obj = Instantiate(
                Resources.Load<PlayerStatus>("PlayerPrefabs/Player" + i)
                , transform.position
                , Quaternion.identity
                ,this.transform);
            obj.gameObject.SetActive(false);
            AllCharactorList.Add(obj);
            i++;
        }
        SelectRandomPlayer();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AllCharactorList[0].Happy += 10;
            Debug.Log(AllCharactorList[0].Happy);
        }
    }
    ////ランダムで重複なしの5人を選択
    private List<int> randomIndex = new();
    void SelectRandomPlayer()
    {
        if(HomeCharactorList.Count > 0) 
        {
            ResetHomeCharactors();
        }
        if(AllCharactorList.Count <= MAX_HOME_CHARACTOR)
        {
            for (int i = 0; i < AllCharactorList.Count; i++)
            {
                HomeCharactorList.Add(AllCharactorList[i]);
            }
        }
        else
        {
            for (int i = 0; i < MAX_HOME_CHARACTOR; i++)
            {
                if(randomIndex.Count == 0)
                {
                    for (int j = 0; j < AllCharactorList.Count; j++)
                    {
                        randomIndex.Add(j);
                    }
                }
                int rand = UnityEngine.Random.Range(0, randomIndex.Count);
                //Debug.Log(randomIndex[rand]);
                HomeCharactorList.Add(AllCharactorList[randomIndex[rand]]);
                randomIndex.Remove(randomIndex[rand]);
            }  
        }
        ActiveHomeCharactors();
    }

    void ActiveHomeCharactors()
    {
        for(int i = 0;i < HomeCharactorList.Count; i++)
        {
            HomeCharactorList[i].transform.position = new Vector3(i + 3 , 0, 0);
            HomeCharactorList[i].gameObject.SetActive(true);
        }
        SetCharactorSortingLayer();
    }
    void ResetHomeCharactors()
    {
        foreach (var obj in HomeCharactorList)
        {
            obj.gameObject.SetActive(false);
        }
        SortOrderList.Clear();
        HomeCharactorList.Clear();
    }
    /// <summary>
    /// プレイヤーレイヤーの管理。
    /// </summary>
    public class SortOrderClass
    {
        public GameObject _gameobject ;
        public Vector3 _nextPosition ;
        public SortOrderClass(in GameObject obj)
        {
            _gameobject = obj;
            _nextPosition = obj.transform.position;
        }
    }
    public void SetCharactorSortingLayer()
    {
        for (int i = 0; i < HomeCharactorList.Count; i++)
        {
            var SpriteArray = HomeCharactorList[i].GetComponentsInChildren<SpriteRenderer>();
            SortOrderList.Add(new SortOrderClass(HomeCharactorList[i].gameObject));
            foreach (var sprite in SpriteArray)
            {
                sprite.sortingOrder = i;
            }
        }
    }
    public void ChangeSortingLayer(string name)
    {
        foreach(var obj in SortOrderList)
        {
            if(obj._gameobject.name == name)
            {
                obj._nextPosition = obj._gameobject.GetComponent<PlayerAnimation>().randomPosition;
            }
        }
        //print("ChangeSortingLayer");
        SortOrderList.Sort((a, b) => a._nextPosition.y.CompareTo( b._nextPosition.y));
        SortOrderList.Reverse();
        for (int i = 0;i < HomeCharactorList.Count; i++)
        {
            //print($"name {SortOrderList[i]._gameobject.name} position {SortOrderList[i]._gameobject.transform.position} order {i}");
            var SpriteArray = SortOrderList[i]._gameobject.GetComponentsInChildren<SpriteRenderer>();
            foreach (var sprite in SpriteArray)
            {
                sprite.sortingOrder = i;
            }
        }
    }


}
