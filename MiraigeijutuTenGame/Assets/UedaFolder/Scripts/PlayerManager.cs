using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;
    public List<PlayerStatus> _allCharactorList = new List<PlayerStatus>();
    public List<PlayerStatus> _homeCharactorList = new List<PlayerStatus>();

    [Flags]
    public enum FoodList
    {
        Rice = 0 << 0,
        Choco = 0 << 1,
        Protain = 0 << 2,
        PizaAndCola = 0 << 3,
        Ice = 0 << 4,
        Salada = 0 << 5,
        KathuCurry = 0 << 6,
        Cake = 0 << 7,
        NutoritionFood  = 0 << 8,
    }
    // Start is called before the first frame update
    void Start()
    {
        int i=0;
        while(Resources.Load<PlayerStatus>("PlayerPrefabs/Player" + i) ? true : false)
        {
            _allCharactorList.Add(Instantiate(
                Resources.Load<PlayerStatus>("PlayerPrefabs/Player" + i)
                ,transform.position + new Vector3(i ,0 , 0)
                ,Quaternion.identity));
            i++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
