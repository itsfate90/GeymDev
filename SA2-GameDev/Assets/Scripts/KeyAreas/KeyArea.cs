using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class KeyArea : MonoBehaviour
{
   [SerializeField] private GameObject welcomePanel;
   [SerializeField] private GameObject interactPanel;
   public TextMeshProUGUI textComponent;
   private int _index;
   public string[] lines;
   public float textSpeed;
   private bool _isPlayerNear;
   private bool _isAlreadyStarted;
   

   private void Start()
   {
      welcomePanel.SetActive(false);
      interactPanel.SetActive(false);
      _isAlreadyStarted = false;
      textComponent.text = String.Empty;
   }

   public void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
      {
         _isPlayerNear = true;
         interactPanel.SetActive(true);
      }
   }

   public void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         
         interactPanel.SetActive(false);
         _isPlayerNear = false;
         StopAllCoroutines();
         textComponent.text = String.Empty;
      }
   }

   private void Update()
   {
      if(_isPlayerNear)
      {
         if (Input.GetKeyDown(KeyCode.E) && !_isAlreadyStarted)
         {
            _isAlreadyStarted = true;
            interactPanel.SetActive(false);
            welcomePanel.SetActive(true);
            StartWelcome();
         }
      }
      else
      {
         welcomePanel.SetActive(false);
         _isAlreadyStarted = false;
      }
   }

   private void StartWelcome()
   {
      _index = 0;
      StartCoroutine(TypeLine());
   }

   IEnumerator TypeLine()
   {
      foreach (char c in lines[_index].ToCharArray())
      {
         textComponent.text += c;
         yield return new WaitForSecondsRealtime(textSpeed);
         
         
      }
   }
}
