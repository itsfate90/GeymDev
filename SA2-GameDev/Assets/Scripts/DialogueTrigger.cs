using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public GameObject DialogueTrigger_1;

    public static bool isDialogueTriggered = false;
    public static bool isDialogue_1_triggered = false;
    public static bool isDialogue_2_triggered = false;
    public static bool isDialogue_3_triggered = false;
    [SerializeField] GameObject Dialogue_1;
    [SerializeField] GameObject Dialogue_2;
    [SerializeField] GameObject Dialogue_3;
   
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DialogueTrigger_1")
        {
            
            isDialogueTriggered = true;
            isDialogue_1_triggered = true;

            Dialogue_1.SetActive(true);
            Dialogue_2.SetActive(false);
            Time.timeScale = 0f;

        }
    }

   

    public void ContinueButton()
    {
        if (isDialogueTriggered)
        {
            if (isDialogue_1_triggered)
            {
                isDialogue_1_triggered = false;
                isDialogue_3_triggered = false;
                Dialogue_1.SetActive(false);
                Dialogue_3.SetActive(false);
                
                Dialogue_2.SetActive(true);
                isDialogue_2_triggered = true;
                Time.timeScale = 0f;
            }
            else if (isDialogue_2_triggered)
            {
                isDialogue_1_triggered = false;
                isDialogue_2_triggered = false;
                Dialogue_1.SetActive(false);
                Dialogue_2.SetActive(false);
                
                Dialogue_3.SetActive(true);
                isDialogue_3_triggered = true;
                Time.timeScale = 0f;
            }
            else if (isDialogue_3_triggered)
            {
                isDialogueTriggered = false;
                isDialogue_1_triggered = false;
                isDialogue_2_triggered = false;
                isDialogue_3_triggered = false;
                Dialogue_1.SetActive(false);
                Dialogue_2.SetActive(false);
                Dialogue_3.SetActive(false);
                
                Time.timeScale = 1f;

            }
            
                
        }
           
 
    }
}
