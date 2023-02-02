using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Area3_Collectible : MonoBehaviour
{
    private int _coins;
    private int _paper;
    [SerializeField] private Text coinText;
    [SerializeField] private Text paperText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private GameObject endFlag;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private Button talkButton;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject chest1;
    [SerializeField] private GameObject chest2;
    [SerializeField] private GameObject chest3;
    private bool _isPanelOpen;
    private bool _isPlayerClose;
    private bool isMobile;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Stars3") == 1)
        {
            _coins = PlayerPrefs.GetInt("CoinSaveCountA3");
            _paper = PlayerPrefs.GetInt("PageSaveCountA3");
        }
       
        PlayerPrefs.Save();
        #if UNITY_STANDALONE_WIN
        isMobile = false;
#elif UNITY_ANDROID || UNITY_IOS
        isMobile = true;
        #endif
        endFlag.SetActive(false);
        endPanel.SetActive(false);
        indicator.SetActive(false);
        _isPanelOpen = false;
        _isPlayerClose = false;
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
        
        if (collision.gameObject.CompareTag("flag"))
        {
            _isPlayerClose = true;
            indicator.SetActive(true);
        }
       
        //coinText.text="Coins:" + _coins;
       // paperText.text="Paper:"+_paper;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("flag"))
        {
            _isPlayerClose = false;
            indicator.SetActive(false);
        }
    }

    private void Update()
    {
        if (_coins >= 35 && _paper == 4)
        {
            endFlag.SetActive(true);
            
        }
        if (_isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isMobile && !_isPanelOpen)
        {
                _isPanelOpen = true;
                endPanel.SetActive(true);
        }

        if (_isPanelOpen && !isMobile && Input.GetKeyDown(KeyCode.Escape))
        {
                Button();
        }

        if (_isPlayerClose && isMobile && !_isPanelOpen)
        {
                talkButton.gameObject.SetActive(true);
                talkButton.onClick.AddListener(InteractButton);
        }

        if (_isPanelOpen && isMobile)
        {
                returnButton.SetActive(true);
        }

        if (_isPanelOpen && Input.GetKeyDown(KeyCode.Return))
        {
            EndGame();
        }

        if (_isPanelOpen) 
        {
            Time.timeScale = 0f; 
        }

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
    public void  Button()
    {
        endPanel.SetActive(false);
        _isPanelOpen = false;
    }

    public void InteractButton()
    {
        _isPanelOpen = true;
        endPanel.SetActive(true);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void SaveCoinPaperCountA3()
    {
        PlayerPrefs.SetInt("Stars3",1);
        PlayerPrefs.SetInt("CoinSaveCountA3",_coins);
        PlayerPrefs.SetInt("PageSaveCountA3",_paper);
        PlayerPrefs.Save();
    }
   
    

    

}
