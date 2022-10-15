
using UnityEngine;

public class KeyArea2 : MonoBehaviour
{
    public bool isPlayerAlreadyEntered;
    [SerializeField]  GameObject welcomeSign;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!isPlayerAlreadyEntered)
        {
            if (col.CompareTag("Player"))
            {
                isPlayerAlreadyEntered = true;
                welcomeSign.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            welcomeSign.SetActive(false);
        }
    }
}
