
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject fallDetector;
    
 
    [SerializeField] GameObject screenDeath;
    [SerializeField] GameObject checkpoint;
   

    void Start()
    {
        respawnPoint = transform.position;
    }
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
            screenDeath.SetActive(true);
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
        Time.timeScale = 1f;
        transform.position = respawnPoint;
    }
}
