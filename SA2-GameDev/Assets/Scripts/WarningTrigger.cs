using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    [SerializeField] GameObject isWarningTrigger;

    
    // Start is called before the first frame update
    void Start()
    {
        isWarningTrigger.SetActive(false);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WarningTrigger")
        {
            isWarningTrigger.SetActive(true);
           

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WarningTrigger")
        {
            isWarningTrigger.SetActive(false);
           
        }
    }
}
