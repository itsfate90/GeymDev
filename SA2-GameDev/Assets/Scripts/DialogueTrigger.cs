using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DialogueTrigger : MonoBehaviour
{
    //public GameObject DialogueTrigger_1;

    private static bool isDialogueTriggered = false;
    [SerializeField] GameObject Dialogue_1;
    [SerializeField] GameObject Dialogue_2;
    [SerializeField] GameObject Dialogue_3;

    
   
    
    
    void Start()
    {
        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(false);
        Dialogue_3.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDialogueTriggered)
        {
            if (collision.tag == "DialogueTrigger_1")
            {
                isDialogueTriggered = true;
                StartCoroutine(WaitBeforeShow());
            }
        }
    }

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DialogueTrigger_1")
        {
            isDialogueTriggered = true;
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
