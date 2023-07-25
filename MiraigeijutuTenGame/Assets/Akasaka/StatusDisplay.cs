using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;

public class StatusDisplay : MonoBehaviour
{
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
        _text = GameObject.Find("StatusWindow/Hungry").GetComponent<Text>();
        _hungryBar = GameObject.Find("StatusWindow/HungryBar").GetComponent<Slider>();
        _happyBar = GameObject.Find("StatusWindow/HappyBar").GetComponent<Slider>();
        _smartBar = GameObject.Find("StatusWindow/SmartBar").GetComponent<Slider>();
        _familiarityBar = GameObject.Find("StatusWindow/FamiliarityBar").GetComponent<Slider>();
    }

    // Update is called once per frame
   
    public void OnMouseDown()
    {
       
        _text.text = "おなか　 :" + _status.Hungry + " \n"
                   + "ごきげん :" + _status.Happy + "\n"
                   + "かしこさ :" + _status.Smart +"\n"
                   + "なつき度 :" + _status.Familiarity;
        _hungryBar.value = _status.Hungry;
        _happyBar.value = _status.Happy;
        _smartBar.value = _status.Smart;
        _familiarityBar.value = _status.Familiarity;
        Vector2 posi = transform.position;
        GameObject.Find("StatusWindow").transform.position = new Vector2(posi.x + 3.3f, posi.y);
        Debug.Log("�G����");
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
