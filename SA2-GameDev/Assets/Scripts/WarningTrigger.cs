
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    [SerializeField] GameObject isWarningTrigger;

    
    void Start()
    {
        isWarningTrigger.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WarningTrigger"))
        {
            isWarningTrigger.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WarningTrigger"))
        {
            isWarningTrigger.SetActive(false);
        }
    }
}
