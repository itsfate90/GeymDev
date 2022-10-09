using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DialogueTrigger : MonoBehaviour
{
    //public GameObject DialogueTrigger_1;

    public static bool isDialogueTriggered = false;
   // public static bool isDialogue_1_triggered = false;
    //public static bool isDialogue_2_triggered = false;
    //public static bool isDialogue_3_triggered = false;
    [SerializeField] GameObject Dialogue_1;
    [SerializeField] GameObject Dialogue_2;
    [SerializeField] GameObject Dialogue_3;
   
    
    
    void Start()
    {
        Dialogue_1.SetActive(false);
        Dialogue_2.SetActive(false);
        Dialogue_3.SetActive(false);

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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DialogueTrigger_1")
        {
            isDialogueTriggered = true;
            StartCoroutine(WaitBeforeShow());

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
        isDialogueTriggered = false;
    }
}
