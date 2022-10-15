
using System.Collections;

using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    private static bool _isDialogueTriggered1;
    [SerializeField] GameObject dialogue1;
    [SerializeField] GameObject dialogue2;
    [SerializeField] GameObject dialogue3;

    void Start()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(false);
        dialogue3.SetActive(false);
        
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
