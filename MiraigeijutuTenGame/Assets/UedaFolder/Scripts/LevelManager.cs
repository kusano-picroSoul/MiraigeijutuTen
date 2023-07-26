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
    /// Start�ȍ~�ŎQ�Ɖ\�BgetOnly
    /// </summary>
    public static LevelManager Instance => instance;
    //���݂̂��ׂẴL�����N�^�[���X�g
    public static List<PlayerStatus> AllCharactorList = new List<PlayerStatus>();

    private const int MAX_HOME_CHARACTOR = 5;
    //���݂̑I������Ă���L�����N�^�[
    public static List<PlayerStatus> HomeCharactorList = new List<PlayerStatus>();
    //�L�����N�^�[�\�����Ԃ��Ǘ����郊�X�g
    public List<SortOrderClass> SortOrderList = new List<SortOrderClass>();
    /// <summary>
    /// �r�b�g�t���O�^�̃t�[�h���X�g(enum)
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
    ////�����_���ŏd���Ȃ���5�l��I��
    private List<int> randomIndex = new();
    public void SelectRandomPlayer()
    {
        //初期化
        if (!(HomeCharactorList == null)) 
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
            for (int j = 0; j < AllCharactorList.Count; j++)
            {
                randomIndex.Add(j);
            }
            for (int i = 0; i < MAX_HOME_CHARACTOR; i++)
            {
                int rand = UnityEngine.Random.Range(0, randomIndex.Count);
                HomeCharactorList.Add(AllCharactorList[randomIndex[rand]]);
                randomIndex.Remove(randomIndex[rand]);
            }
            randomIndex.Clear();
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
        for (int i = 0; i < HomeCharactorList.Count; i++)
        {
            HomeCharactorList[i].GetComponent<PlayerAnimation>().ActiveAnimation();
        }      
    }
    void ResetHomeCharactors()
    {
        foreach (var obj in HomeCharactorList)
        {
            obj.GetComponent<PlayerAnimation>().StopAmnimation();
            obj.gameObject.SetActive(false);
        }
        SortOrderList.Clear();
        HomeCharactorList.Clear();
    }
    /// <summary>
    /// �v���C���[���C���[�̊Ǘ��B
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
            if(name == "Food")
            {
                obj._nextPosition = obj._gameobject.transform.position;
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
