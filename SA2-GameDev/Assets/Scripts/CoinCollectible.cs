using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectible : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource collectionSoundEffect;
     [SerializeField] private GameObject portal;
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            
                Instantiate(portal,new Vector3(1023,22,0),Quaternion.identity);
           
            coinText.text="Coins:" + coins;
           
        }
    }
}
