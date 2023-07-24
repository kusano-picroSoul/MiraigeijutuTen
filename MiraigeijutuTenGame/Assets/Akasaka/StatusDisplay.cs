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
    [SerializeField] Text _text;
    [SerializeField] bool _active = false;
    [SerializeField] Slider _hungryBar;
    [SerializeField] Slider _happyBar;
    [SerializeField] Slider _smartBar;
    //[SerializeField] Slider _helthBar;
    PlayerStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<PlayerStatus>();
       _text.enabled = false;
       _hungryBar.gameObject.SetActive(false);
       _happyBar.gameObject.SetActive(false);
       _smartBar.gameObject.SetActive(false);
      // _helthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        //_status.Happy
        //PlayerConditionUpdate();
        _text.text = "Ç®Ç»Ç©Å@ :" + _status.Hungry + "\n"
               + "Ç≤Ç´Ç∞ÇÒ :" + _status.Happy + "\n"
               + "Ç©ÇµÇ±Ç≥ :" + _status.Smart;
        _hungryBar.value = _status.Hungry;
        _happyBar.value = _status.Happy;
        _smartBar.value = _status.Smart;
        Vector2 posi = GameObject.Find("Player0").transform.position;
        GameObject.Find("Canvas").transform.position = new Vector2(posi.x + 3.3f, posi.y);
    }

    public void OnMouseDown()
    {
        Debug.Log("êGÇ¡ÇΩ");
        if (_active == false)
        {
            _text.enabled = true;
            _hungryBar.gameObject.SetActive(true);
            _happyBar.gameObject.SetActive(true);
            _smartBar.gameObject.SetActive(true);
            //_helthBar.gameObject.SetActive(true);
            _active = true;
        }
        else
        {
            _text.enabled = false;
            _hungryBar.gameObject.SetActive(false);
            _happyBar.gameObject.SetActive(false);
            _smartBar.gameObject.SetActive(false);
           // _helthBar.gameObject.SetActive( false);
            _active = false;
        }
    }
}
