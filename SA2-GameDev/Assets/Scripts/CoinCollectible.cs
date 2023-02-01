using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectible : MonoBehaviour
{
   
    private int _coins;
    private int _paper;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
     [SerializeField] private GameObject portal;

     private void Start()
     {
         _coins = PlayerPrefs.GetInt("CoinSaveCount");
         _paper = PlayerPrefs.GetInt("PageSaveCount");
         PlayerPrefs.Save();
     }

     private void OnTriggerEnter2D(Collider2D collision) {

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
        if(_coins >= 35 && _paper == 3){
            Instantiate(portal,new Vector3(1048,-2,0),Quaternion.identity);
        }
        //coinText.text="Coins:" + _coins;
        
        //paperText.text="Paper:"+_paper;
     }

     public void SaveCoinCount()
     {
         PlayerPrefs.SetInt("CoinSaveCount",_coins);
         PlayerPrefs.SetInt("PageSaveCount",_paper);
         PlayerPrefs.Save();
     }

     private void Update()
     {
         coinText.text = "Coins: " + _coins;
         paperText.text = " Paper: " + _paper;
     }
}
