using UnityEngine;

public class OpenInventory : MonoBehaviour
{
   private bool _isPage1;
   private bool _isPage2;
   private bool _isPage3;

   private bool _isPage1Open;
   private bool _isPage2Open;
   //private bool _isPage3Open;

   [SerializeField] private GameObject atiPanel;
   [SerializeField] private GameObject florPanel;
   [SerializeField] private GameObject panPanel;
   [SerializeField] private GameObject empPanel;
   [SerializeField] private GameObject pauseMenu;
   

   private void Start()
   {
      _isPage1 = false;
      _isPage2 = false;
      _isPage3 = false;
      
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      empPanel.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("TornPaper"))
      {
         _isPage1 = true;
      }

      if (col.CompareTag("TornPaper2"))
      {
         _isPage2 = true;
      }

      if (col.CompareTag("TornPaper3"))
      {
         _isPage3 = true;
      }
   }

   public  void OpenBook()
   {
      pauseMenu.SetActive(false);
      if (_isPage1)
      {
         atiPanel.SetActive(true);
         _isPage1Open = true;
      }
      else if (!_isPage1)
      {
         empPanel.SetActive(true);
         _isPage1Open = true;
      }
   }

   public void NextPage1()
   {
      
      atiPanel.SetActive(false);
      if (_isPage1Open)
      {
         _isPage1Open = false;
         if (_isPage2)
         {
            empPanel.SetActive(false);
            florPanel.SetActive(true);
            _isPage2Open = true;
            
         }
         else if(!_isPage2)
         {
            empPanel.SetActive(true);
            _isPage2Open = true;
            
         }
         
      }
      else if(_isPage2Open)
      {
         florPanel.SetActive(false);
         _isPage2Open = false;
         if (_isPage3)
         {
            empPanel.SetActive(false);
            panPanel.SetActive(true);
            //_isPage3Open = true;
         }
         else if (!_isPage3)
         {
            empPanel.SetActive(true);
            //_isPage3Open = true;
         }
      }
   }

   public void CloseMenu()
   {
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      empPanel.SetActive(false);
      pauseMenu.SetActive(true);
   }
}
