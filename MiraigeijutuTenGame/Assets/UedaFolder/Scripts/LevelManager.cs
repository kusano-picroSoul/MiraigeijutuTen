using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Threading;
using UnityEngine.UIElements;
using System.Linq;

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
                , transform.position + new Vector3(i, 0, 0)
                , Quaternion.identity);
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
        HomeCharactorList.Clear();
        if(AllCharactorList.Count <= 5)
        {
            for (int i = 0; i < AllCharactorList.Count; i++)
            {
                HomeCharactorList.Add(AllCharactorList[i]);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
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
        foreach (var obj in HomeCharactorList)
        {
            obj.gameObject.SetActive(true);
        }
        SetCharactorSortingLayer();
    }

    /// <summary>
    /// プレイヤーレイヤーの管理。
    /// </summary>
    public class SortOrderClass
    {
        public int _sortingOrderID = 0;
        public Transform _transform ;
        public SortOrderClass(int sortingOrderID, in Transform transform)
        {
            _sortingOrderID = sortingOrderID;
            _transform = transform;
        }
    }
    public List<SortOrderClass> SortOrderList = new List<SortOrderClass>();
    private void SetCharactorSortingLayer()
    {
        for (int i = 0; i < HomeCharactorList.Count; i++)
        {
            var SpriteArray = HomeCharactorList[i].GetComponentsInChildren<SpriteRenderer>();
            SortOrderList.Add(new SortOrderClass(i, HomeCharactorList[i].transform));
            foreach (var sprite in SpriteArray)
            {
                sprite.sortingOrder = i;
            }
        }
    }
    public void ChangeSortingLayer()
    {
        print("ChangeSortingLayer");
        SortOrderList.Sort((a, b) => a._transform.position.y.CompareTo( b._transform.position.y));
        SortOrderList.Reverse();
        for (int i = 0;i < HomeCharactorList.Count; i++)
        {
            print($"name {HomeCharactorList[i].name} position {SortOrderList[i]._transform.position} order {i}");
            var SpriteArray = HomeCharactorList[i].GetComponentsInChildren<SpriteRenderer>();
            foreach (var sprite in SpriteArray)
            {
                sprite.sortingOrder = SortOrderList[i]._sortingOrderID;
            }
        }
       
    }


}
