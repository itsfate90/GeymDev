using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectible : MonoBehaviour
{

    private int _coins;
    private int _paper;
    private int _coinCount;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject chest1;
    [SerializeField] private GameObject chest2;
    [SerializeField] private GameObject chest3;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Stars") == 1)
        {
            _coins = PlayerPrefs.GetInt("CoinSaveCount");
            _paper = PlayerPrefs.GetInt("PageSaveCount");
            PlayerPrefs.Save();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
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

        if (_coins >= 35 && _paper == 3)
        {
            Instantiate(portal, new Vector3(1048, -2, 0), Quaternion.identity);
        }
        //coinText.text="Coins:" + _coins;

        //paperText.text="Paper:"+_paper;
    }

    public void SaveCoinPaperCount()
    {
        PlayerPrefs.SetInt("Stars", 1);
        PlayerPrefs.SetInt("CoinSaveCount", _coins);
        PlayerPrefs.SetInt("PageSaveCount", _paper);
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
     


