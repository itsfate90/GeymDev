using System;
using UnityEngine;
using UnityEngine.UI;

public class Area3_Collectible : MonoBehaviour
{
    private int _coins;
    private int _paper;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private GameObject endFlag;
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        endFlag.SetActive(false);
        endPanel.SetActive(false);
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
        if(_coins >= 30 && _paper==4 )
        {
            endFlag.SetActive(true);   
        }

        if (collision.gameObject.CompareTag("flag"))
        {
            endPanel.SetActive(true);   
        }
       
        coinText.text="Coins:" + _coins;
        paperText.text="Paper:"+_paper;

    }
}
