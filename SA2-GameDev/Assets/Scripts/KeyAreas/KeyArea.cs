using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class KeyArea : MonoBehaviour
{
   [SerializeField] private GameObject welcomePanel;
   [SerializeField] private GameObject interactPanel;
   [SerializeField] private GameObject talkButton;
   public TextMeshProUGUI textComponent;
   private int _index;
   public string[] lines;
   public float textSpeed;
   private bool _isPlayerNear;
   private bool _isAlreadyStarted;
   private bool _isMobile;
   

   private void Start()
   {
      #if UNITY_STANDALONE_WIN
      _isMobile = false;
      #endif
      #if UNITY_IOS
      _isMobile = true;
#endif
      #if UNITY_ANDROID
      _isMobile = true;
      #endif
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
         _isAlreadyStarted = false;
         welcomePanel.SetActive(false);
      }
   }

   private void Update()
   {
      if(_isPlayerNear)
      {
         if (Input.GetKeyDown(KeyCode.E) && !_isAlreadyStarted && !_isMobile)
         {
            _isAlreadyStarted = true;
            interactPanel.SetActive(false);
            welcomePanel.SetActive(true);
            StartWelcome();
         }
      }

      if (_isPlayerNear && _isMobile)
      {
         talkButton.SetActive(true);
      }
      else
      {
         talkButton.SetActive(false);
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

   public void InteractButton()
   {
      _isAlreadyStarted = true;
      interactPanel.SetActive(false);
      welcomePanel.SetActive(true);
      StartWelcome();
   }
}
