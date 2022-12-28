
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject fallDetector;
    
 
    [SerializeField] GameObject screenDeath;
    [SerializeField] GameObject checkpoint;
    private bool _isRespawnScreenActive;
   

    void Start()
    {
        respawnPoint = transform.position;
        _isRespawnScreenActive = false;
    }
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
            screenDeath.SetActive(true);
            _isRespawnScreenActive = true;
            Time.timeScale = 0f;
        }
        else if (collision.CompareTag("Checkpoint"))
        {   
            respawnPoint = transform.position;
            checkpoint.SetActive(true);
             
        }
        else if (collision.CompareTag("Enemy"))
        {
            screenDeath.SetActive(true);
            _isRespawnScreenActive = true;
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpoint.SetActive(false);
        }
    }
    

    public void RespawnButton()
    {
        screenDeath.SetActive(false);
        _isRespawnScreenActive = false;
        Time.timeScale = 1f;
        transform.position = respawnPoint;
    }
}
