using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DialogueTrigger : MonoBehaviour
{
    //public GameObject DialogueTrigger_1;

    private static bool isDialogueTriggered_1 = false;
    private static bool isDialogueTriggered_2 = false;
    [SerializeField] GameObject Dialogue_1;
    [SerializeField] GameObject Dialogue_2;
    [SerializeField] GameObject Dialogue_3;
    [SerializeField] GameObject Dialogue_4;
    

    
   
    
    
    void Start()
    {
        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(false);
        Dialogue_3.SetActive(false);
        Dialogue_4.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDialogueTriggered_1)
        {
            if (collision.tag == "DialogueTrigger_1")
            {
                isDialogueTriggered_1 = true;
                StartCoroutine(WaitBeforeShow());
            }
        }

        if (!isDialogueTriggered_2)
        {
            if(collision.tag == "DialogueTrigger_2")
            {
                Dialogue_4.SetActive(true);
                isDialogueTriggered_2 = true;
            }
            
        }
    }

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DialogueTrigger_2")
        {
            Dialogue_4.SetActive(false);
        }
   }

    IEnumerator WaitBeforeShow()
    {
        Dialogue_1.SetActive(true);
        yield return new WaitForSeconds(1);
        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(true);
        yield return new WaitForSeconds(1);
        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(true);
        yield return new WaitForSeconds(1);
        Dialogue_2.SetActive(false);
        Dialogue_3.SetActive(true);
        yield return new WaitForSeconds(1);
        Dialogue_3.SetActive(false);
        
    }
}
