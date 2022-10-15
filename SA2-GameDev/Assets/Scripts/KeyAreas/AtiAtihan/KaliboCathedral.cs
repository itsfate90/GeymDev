using UnityEngine;

public class KaliboCathedral : MonoBehaviour
{
   [SerializeField] GameObject kaliboPanel;

   private void OnTriggerEnter2D(Collider2D col)
   {
      if(col.CompareTag("Player"))
      {
         kaliboPanel.SetActive(true);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         kaliboPanel.SetActive(false);
      }
   }
}
