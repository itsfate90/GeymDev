
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    private static bool _isWarningDialogueTriggered;
    [SerializeField] GameObject isWarningTrigger;
    [SerializeField] GameObject warningDialogue;

    
    void Start()
    {
        isWarningTrigger.SetActive(false);
        warningDialogue.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WarningTrigger"))
        {
            isWarningTrigger.SetActive(true);
        }

        if (!_isWarningDialogueTriggered)
        {
            if (collision.CompareTag("WarningTrigger"))
            {
                warningDialogue.SetActive(true);
                _isWarningDialogueTriggered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WarningTrigger"))
        {
            isWarningTrigger.SetActive(false);
            warningDialogue.SetActive(false);
        }
    }
}
