using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public Vector3 respawnPoint;
    public GameObject fallDetector;
    public GameObject fallDetector2;

    [SerializeField] GameObject screenDeath;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position; 

    }

    // Update is called once per frame
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        fallDetector2.transform.position = new Vector2(transform.position.x, fallDetector2.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            screenDeath.SetActive(true);
            Time.timeScale = 0f;
            //transform.position = respawnPoint;
        }
        else if (collision.tag == "FallDetector2") // create new tag for trap and copy paste the folllowing
        {
            screenDeath.SetActive(true);
            Time.timeScale = 0f;
            //transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        
    }

    public void respawnButton()
    {
        screenDeath.SetActive(false);
        Time.timeScale = 1f;
        transform.position = respawnPoint;
    }
}
