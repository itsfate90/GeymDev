
using System.Collections;

using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    private static bool _isDialogueTriggered1;
    private static bool _isDialogueTriggered2;
    [SerializeField] GameObject dialogue1;
    [SerializeField] GameObject dialogue2;
    [SerializeField] GameObject dialogue3;
    [SerializeField] GameObject dialogue4;
    

    
   
    
    
    void Start()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(false);
        dialogue3.SetActive(false);
        dialogue4.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isDialogueTriggered1)
        {
            if (collision.CompareTag("DialogueTrigger_1"))
            {
                _isDialogueTriggered1 = true;
                StartCoroutine(WaitBeforeShow());
            }
        }

        if (!_isDialogueTriggered2)
        {
            if(collision.CompareTag("DialogueTrigger_2"))
            {
                dialogue4.SetActive(true);
                _isDialogueTriggered2 = true;
            }
            
        }
    }

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogueTrigger_2"))
        {
            dialogue4.SetActive(false);
        }
    }

   IEnumerator WaitBeforeShow()
   {
       dialogue1.SetActive(true);
       yield return new WaitForSeconds(1);
       dialogue1.SetActive(false);
       dialogue2.SetActive(true);
       yield return new WaitForSeconds(1);
       dialogue2.SetActive(false);
       dialogue3.SetActive(true);
       yield return new WaitForSeconds(1);
       dialogue3.SetActive(false);
   }
}
