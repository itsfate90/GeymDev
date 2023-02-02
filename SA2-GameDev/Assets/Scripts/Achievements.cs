using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    [SerializeField] private GameObject chest1A;
    [SerializeField] private GameObject chest1B;
    [SerializeField] private GameObject chest1C;
    [SerializeField] private GameObject chest2A;
    [SerializeField] private GameObject chest2B;
    [SerializeField] private GameObject chest2C;
    
    private int _coinCount1;

    private int _coinCount2;

    private int _coinCount3;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("CoinSaveCount");
        _coinCount1 = PlayerPrefs.GetInt("CoinSaveCount");
        _coinCount2 = PlayerPrefs.GetInt("CoinSaveCountA2");
        _coinCount3 = PlayerPrefs.GetInt("CoinSaveCountA3");
    }

    private void Update()
    {
       
        if (_coinCount1 >= 10 && _coinCount1 < 20)
        {
            chest1A.SetActive(true);
            chest1B.SetActive(false);
            chest1C.SetActive(false);
        }
        else if (_coinCount1 >= 20 && _coinCount1 <30)
        {
            chest1A.SetActive(true);
            chest1B.SetActive(true);
            chest1C.SetActive(false);
        }
        else if (_coinCount1 >= 30)
        {
            chest1A.SetActive(true);
            chest1B.SetActive(true);
            chest1C.SetActive(true);
        }
        if (_coinCount2 >= 10 && _coinCount2 < 20)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(false);
            chest2C.SetActive(false);
        }
        else if (_coinCount2 >= 20 && _coinCount2 <30)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(true);
            chest2C.SetActive(false);
        }
        else if (_coinCount2 >= 30)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(true);
            chest2C.SetActive(true);
        }
        if (_coinCount3 >= 10 && _coinCount3 < 20)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(false);
            chest2C.SetActive(false);
        }
        else if (_coinCount3 >= 20 && _coinCount3 <30)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(true);
            chest2C.SetActive(false);
        }
        else if (_coinCount3 >= 30)
        {
            chest2A.SetActive(true);
            chest2B.SetActive(true);
            chest2C.SetActive(true);
        }
        
    }
   
}
