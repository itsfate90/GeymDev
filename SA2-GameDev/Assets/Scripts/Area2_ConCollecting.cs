using System;
using UnityEngine;
using UnityEngine.UI;

public class Area2_ConCollecting : MonoBehaviour
{
    private int _coins;
    private int _paper;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
     [SerializeField] private GameObject portal;
     [SerializeField] private GameObject chest1;
     [SerializeField] private GameObject chest2;
     [SerializeField] private GameObject chest3;


     private void Start()
     {
         if (PlayerPrefs.GetInt("Stars2") == 1)
         {
             _coins = PlayerPrefs.GetInt("CoinSaveCountA2");
             _paper = PlayerPrefs.GetInt("PageSaveCountA2");
             PlayerPrefs.Save();
         }
         if(_coins >= 10 && _paper==3 ){
             Instantiate(portal,new Vector3(-1200,-1,0),Quaternion.identity);
         }
         
     }

     private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            _coins++;
        }

        else if (collision.gameObject.CompareTag("Pages"))
        {
            Destroy(collision.gameObject);
            _paper++;
        }
        if(_coins >= 10 && _paper==3 ){
            PlayerPrefs.SetInt("CoinSaveCountA2",_coins);
            PlayerPrefs.SetInt("PageSaveCountA2",_paper);
            Instantiate(portal,new Vector3(-1200,-1,0),Quaternion.identity);
        }
        //coinText.text="Coins:" + _coins;
       // paperText.text="Paper:"+_paper;

    }

    public void SaveCoinPaperCountA2()
    {
        PlayerPrefs.SetInt("Stars2",1);
        PlayerPrefs.SetInt("CoinSaveCountA2",_coins);
        PlayerPrefs.SetInt("PageSaveCountA2",_paper);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        coinText.text = "Coins: " + _coins;
        paperText.text = " Paper: " + _paper;
        
        if (_coins >= 10 && _coins < 20)
        {
            chest1.SetActive(true);
            chest2.SetActive(false);
            chest3.SetActive(false);
        }
        else if (_coins >= 20 && _coins <30)
        {
            chest1.SetActive(true);
            chest2.SetActive(true);
            chest3.SetActive(false);
        }
        else if (_coins >= 30)
        {
            chest1.SetActive(true);
            chest2.SetActive(true);
            chest3.SetActive(true);
        }
    }
    
}
