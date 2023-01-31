
using UnityEngine;

public class HealthCount : MonoBehaviour
{
    public static int Health;
    public Vector3 respawnPoint;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject heart4;
    [SerializeField] private GameObject heart5;

    [SerializeField] private GameObject screenDeath;
    private bool _isRespawnScreenActive;

    private void Start()
    {
        respawnPoint = transform.position;
        _isRespawnScreenActive = false;
        Health =5;
        FullHealth();
    }

    private void Update()
    {
        switch (Health)
        {
            case 5:
                FullHealth();
                break;
            case 4:
                FourHp();
                break;
            case 3:
                ThreeHp();
                break;
            case 2:
                TwoHp();
                break;
            case 1:
                OneHP();
                break;
            case 0:
                ZeroHp();
                Time.timeScale = 0f;
                screenDeath.SetActive(true);
                _isRespawnScreenActive = true;
                break;
                
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isRespawnScreenActive)
        {
            RespawnButton();
        }

        if (Input.GetMouseButtonDown(0) && _isRespawnScreenActive)
        {
            RespawnButton();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && _isRespawnScreenActive)
        {
            RespawnButton();
        }
    }

    private void FullHealth()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
    }
    private void FourHp()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(false);
    }
    private void ThreeHp()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(false);
        heart5.SetActive(false);
    }
    private void TwoHp()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(false);
        heart4.SetActive(false);
        heart5.SetActive(false);
    }
    private void OneHP()
    {
        heart1.SetActive(true);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heart4.SetActive(false);
        heart5.SetActive(false);
    }

    private void ZeroHp()
    {
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heart4.SetActive(false);
        heart5.SetActive(false);
    }
   
    public void RespawnButton()
    {
        
        screenDeath.SetActive(false);
        _isRespawnScreenActive = false;
        Time.timeScale = 1f;
        transform.position = respawnPoint;
        Health = 5;
    }
    

   
}
