using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop_up_message : MonoBehaviour
{
    public GameObject Message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
