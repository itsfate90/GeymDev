using System.Collections;
using UnityEngine;



public class Dialogue1 : MonoBehaviour
{
  [SerializeField] GameObject dialogue1;
  [SerializeField] GameObject dialogue1B;
  [SerializeField] GameObject dialogue1C;
  
  public bool isDialogue1AlreadyTriggered;

  private void OnTriggerEnter2D(Collider2D col)
  {
    if (!isDialogue1AlreadyTriggered)
    {
      if (col.CompareTag("Player"))
      {
        isDialogue1AlreadyTriggered = true;
        StartCoroutine(WaitBeforeShow());
        
      }
    }
  }

  IEnumerator WaitBeforeShow()
  {
    dialogue1.SetActive(true);
    yield return new WaitForSecondsRealtime(1);
    dialogue1.SetActive(false);
    dialogue1B.SetActive(true);
    yield return new WaitForSecondsRealtime(1);
    dialogue1B.SetActive(false);
    dialogue1C.SetActive(true);
    yield return new WaitForSecondsRealtime(1);
    dialogue1C.SetActive(false);
  }
}
