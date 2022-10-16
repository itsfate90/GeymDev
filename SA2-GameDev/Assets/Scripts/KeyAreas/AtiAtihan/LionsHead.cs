using UnityEngine;

public class LionsHead : MonoBehaviour
{
    [SerializeField] GameObject lionsHeadPanel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            lionsHeadPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lionsHeadPanel.SetActive(false);
        }
    }
}
