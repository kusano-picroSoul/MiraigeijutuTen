using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.Diagnostics;

public class Status
{
    public ReactiveProperty<int> _hungry = new(50);
    public ReactiveProperty<int> _happy = new(50);
    public ReactiveProperty<int> _smart = new(50);
    public ReactiveProperty<int> _helth = new(50);
    public ReactiveProperty<int> _familiarity = new(50);
}
public class PlayerStatus :MonoBehaviour
{
    int MaxStatusValue = 1000;
    public Status status = new();
    //クラスをインスタンス化したものは検知することが出来ない。
    public ReactiveProperty<Condition> PlayerCondition = new ReactiveProperty<Condition>(Condition.Normal);
    public int Hungry
    {
        set { status._hungry.Value = Mathf.Clamp(value,0, MaxStatusValue); }
        get 
        { 
            return status._hungry.Value; 
        }
    }
    public int Happy
    {
        set { status._happy.Value = Mathf.Clamp(value,0, MaxStatusValue);}
        get { return status._happy.Value; } 
    }
    public int Smart
    {
        set { status._smart.Value = Mathf.Clamp(value, 0, MaxStatusValue); }
        get { return status._smart.Value; }
    }
    public int Health
    {
        set { status._helth.Value = Mathf.Clamp(value, 0, MaxStatusValue); }
        get { return status._helth.Value; }
    }
    public int Familiarity
    {
        set { status._familiarity.Value = Mathf.Clamp(value, 0, MaxStatusValue); }
        get { return status._familiarity.Value; }
    }

    ////プレイヤーコンディションの管理
    public void PlayerConditionUpdate()
    {
        //Debug.Log("呼ばれた");
        if (Health <= 0 )
        {
            PlayerCondition.Value = Condition.Tired;
        }
        else if (Hungry <= 0)
        {
            PlayerCondition.Value = Condition.Hungry;
        }
        else if (Smart <= 0)
        {
            PlayerCondition.Value = Condition.Stupid;
        }
        else if (Happy <= 0)
        {
            PlayerCondition.Value = Condition.Angry;
        }
        else if (Happy >= 80)
        {
            PlayerCondition.Value = Condition.Happy;
        }
        else
        {
            PlayerCondition.Value = Condition.Normal;
        }
    }


}
