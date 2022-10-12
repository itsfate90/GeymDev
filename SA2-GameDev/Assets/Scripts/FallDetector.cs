using System;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject fallDetector;
    public GameObject fallDetector2;

    [SerializeField] GameObject screenDeath;
    [SerializeField] GameObject Checkpoint;
    void Start()
    {
        respawnPoint = transform.position;
    }
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        fallDetector2.transform.position = new Vector2(transform.position.x, fallDetector2.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
            screenDeath.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (collision.CompareTag("FallDetector2")) // create new tag for trap and copy paste the folllowing
        {
            screenDeath.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
            Checkpoint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            Checkpoint.SetActive(false);
        }
    }

    public void RespawnButton()
    {
        screenDeath.SetActive(false);
        Time.timeScale = 1f;
        transform.position = respawnPoint;
    }
}
