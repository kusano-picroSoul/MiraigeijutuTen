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
    GameObject _StatusBG;
    //[SerializeField] Slider _helthBar;
    PlayerStatus _status;
    // Start is called before the first frame update
    List<Vector3> _statusBarDefaultPositions = new();

    Transform _statusWindow;
    Vector3 _defaultStatusWindowPosition;
    void Start()
    {
        _statusWindow = GameObject.Find("StatusWindow").transform;
        _defaultStatusWindowPosition = _statusWindow.position;
        _status = GetComponent<PlayerStatus>();
        _text = GameObject.Find("StatusWindow/Hungry").GetComponent<Text>();
        _hungryBar = GameObject.Find("StatusWindow/HungryBar").GetComponent<Slider>();
        _happyBar = GameObject.Find("StatusWindow/HappyBar").GetComponent<Slider>();
        _smartBar = GameObject.Find("StatusWindow/SmartBar").GetComponent<Slider>();
        _familiarityBar = GameObject.Find("StatusWindow/FamiliarityBar").GetComponent<Slider>();
        _StatusBG = GameObject.Find("StatusBG");
        _statusBarDefaultPositions.Add(_hungryBar.gameObject.transform.position);
        _statusBarDefaultPositions.Add(_happyBar.gameObject.transform.position);
        _statusBarDefaultPositions.Add(_smartBar.gameObject.transform.position);
        _statusBarDefaultPositions.Add(_familiarityBar.gameObject.transform.position);
        _statusBarDefaultPositions.Add(_StatusBG.gameObject.transform.position);

    }

    // Update is called once per frame

    private void OnMouseDrag()
    {
        _text.text = "おなか　 :" + _status.Hungry + "\n"
                   + "ごきげん :" + _status.Happy + "\n"
                   + "かしこさ :" + _status.Smart + "\n"
                   + "なつき度 :" + _status.Familiarity;
        _hungryBar.value = _status.Hungry;
        _happyBar.value = _status.Happy;
        _smartBar.value = _status.Smart;
        _familiarityBar.value = _status.Familiarity;
    }

    public void OnMouseDown()
    {
        Vector2 posi = transform.position;
        if (posi.x < 0)
           _statusWindow.position = new Vector2(posi.x + 3.3f, posi.y);
        else
            _statusWindow.position = GameObject.Find("StatusWindow").transform.position = new Vector2(posi.x - 0.7f, posi.y);
        Debug.Log("�G����");
        //if (_active == false)
        //{
        //    _text.enabled = true;
        //    _hungryBar.gameObject.SetActive(true);
        //    _happyBar.gameObject.SetActive(true);
        //    _smartBar.gameObject.SetActive(true);
        //    _familiarityBar.gameObject.SetActive(true);
        //    _StatusBG.SetActive(true);
        //    //_helthBar.gameObject.SetActive(true);
        //    _active = true;
        //}
    }
    private void OnMouseUp()
    {
        _statusWindow.position = _defaultStatusWindowPosition;
        //if(_active == true)
        //{
        //    _text.enabled = false;
        //    _hungryBar.gameObject.transform.position = _statusBarDefaultPositions[0];
        //    _happyBar.gameObject.transform.position = _statusBarDefaultPositions[1];
        //    _smartBar.gameObject.transform.position = _statusBarDefaultPositions[2];
        //    _familiarityBar.gameObject.transform.position = _statusBarDefaultPositions[3];
        //    _StatusBG.transform.position = _statusBarDefaultPositions[4];
        //    // _helthBar.gameObject.SetActive( false);
        //    _active = false;
        //}
    }
}
