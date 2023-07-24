using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;

public class StatusDisplay : MonoBehaviour
{
    //public ReactiveProperty<int> _hungry = new(50);
    //public ReactiveProperty<int> _happy = new(50);
    //public ReactiveProperty<int> _smart = new(50);
    //public ReactiveProperty<int> _helth = new(50);
    Text _text;
    [SerializeField] bool _active = false;
    Slider _hungryBar;
    Slider _happyBar;
    Slider _smartBar;
    Slider _familiarityBar;
    //[SerializeField] Slider _helthBar;
    PlayerStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<PlayerStatus>();
        _text = GameObject.Find("Canvas/Hungry").GetComponent<Text>();
        _hungryBar = GameObject.Find("Canvas/HungryBar").GetComponent<Slider>();
        _happyBar = GameObject.Find("Canvas/HappyBar").GetComponent<Slider>();
        _smartBar = GameObject.Find("Canvas/SmartBar").GetComponent<Slider>();
        _familiarityBar = GameObject.Find("Canvas/FamiliarityBar").GetComponent<Slider>();
        _hungryBar.gameObject.SetActive(false);
        _happyBar.gameObject.SetActive(false);
        _smartBar.gameObject.SetActive(false);
        _familiarityBar.gameObject.SetActive(false);
        _text.enabled = false;
        // _helthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        //_status.Happy
        //PlayerConditionUpdate();
       
    }

    public void OnMouseDown()
    {
        _text.text = "Ç®Ç»Ç©       :" + _status.Hungry + "\n"
                   + "Ç≤Ç´Ç∞ÇÒ    :" + _status.Happy + "\n"
                   + "Ç©ÇµÇ±Ç≥    :" + _status.Smart +"\n"
                   + "Ç»Ç©ÇÊÇµìx :" + _status.Familiarity;
        _hungryBar.value = _status.Hungry;
        _happyBar.value = _status.Happy;
        _smartBar.value = _status.Smart;
        _familiarityBar.value = _status.Familiarity;
        Vector2 posi = transform.position;
        GameObject.Find("Canvas").transform.position = new Vector2(posi.x + 3.3f, posi.y);
        Debug.Log("êGÇ¡ÇΩ");
        if (_active == false)
        {
            _text.enabled = true;
            _hungryBar.gameObject.SetActive(true);
            _happyBar.gameObject.SetActive(true);
            _smartBar.gameObject.SetActive(true);
            _familiarityBar.gameObject.SetActive(true);
            //_helthBar.gameObject.SetActive(true);
            _active = true;
        }
    }
    private void OnMouseUp()
    {
        if(_active == true)
        {
            _text.enabled = false;
            _hungryBar.gameObject.SetActive(false);
            _happyBar.gameObject.SetActive(false);
            _smartBar.gameObject.SetActive(false);
            _familiarityBar.gameObject.SetActive(false);
            // _helthBar.gameObject.SetActive( false);
            _active = false;
        }
    }
}
