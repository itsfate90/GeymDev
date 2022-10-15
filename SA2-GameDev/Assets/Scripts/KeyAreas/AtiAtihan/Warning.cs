using UnityEngine;

public class Warning : MonoBehaviour
{
   [SerializeField] GameObject warningSign;
   [SerializeField] GameObject warningDialogue;
   private bool _isWarningDialogueTriggered;

   void Start()
   {
      warningSign.SetActive(false);
      warningDialogue.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (!_isWarningDialogueTriggered)
      {
         if (col.CompareTag("Player"))
         {
            warningDialogue.SetActive(true);
            _isWarningDialogueTriggered = true;
            warningSign.SetActive(true);
         }
      }
      else
      {
         warningSign.SetActive(true);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         warningDialogue.SetActive(false);
         warningSign.SetActive(false);
      }
   }
}
