using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectible : MonoBehaviour
{
    private int Coin = 0;
    [SerializeField] private Text coinText;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Coin")){
            Destroy(collision.gameObject);
            Coin++;
            coinText.text = "Coins:" + Coin;
        }
    }
}
