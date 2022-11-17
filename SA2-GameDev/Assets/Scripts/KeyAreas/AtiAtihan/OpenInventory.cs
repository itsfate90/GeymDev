using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenInventory : MonoBehaviour
{
   private bool _isPage1;
   private bool _isPage2;
   private bool _isPage3;

   private bool _isPage4;
   private bool _isPage5;
   private bool _isPage6;

   private bool _isPage1Open;
   private bool _isPage2Open;
   private bool _isPage3Open;

   private bool _isPage4Open;
   private bool _isPage5Open;
   //private bool _isPage6Open;

   [SerializeField] private GameObject atiPanel;
   [SerializeField] private GameObject florPanel;
   [SerializeField] private GameObject panPanel;
   [SerializeField] private GameObject empPanel;
   [SerializeField] private GameObject pauseMenu;
   [SerializeField] private GameObject sipaPanel;
   [SerializeField] private GameObject patinteroPanel;
   [SerializeField] private GameObject pikoPanel;
   
   
   

   private void Start()
   {
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      sipaPanel.SetActive(false);
      patinteroPanel.SetActive(false);
      pikoPanel.SetActive(false);
      empPanel.SetActive(false);
      

      Scene currentScene = SceneManager.GetActiveScene();
      string sceneName = currentScene.name;

      if (sceneName == "SampleScene")
      {
         _isPage1 = false;
         _isPage2 = false;
         _isPage3 = false;
      }
      else if (sceneName == "Area2")
      {
         _isPage1 = true;
         _isPage2 = true;
         _isPage3 = true;
      }
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

      if (col.CompareTag("TornPaper4"))
      {
         _isPage4 = true;
      }

      if (col.CompareTag("TornPaper5"))
      {
         _isPage5 = true;
      }

      if (col.CompareTag("TornPaper6"))
      {
         _isPage6 = true;
      }
   }

   public  void OpenBook()
   {
      Time.timeScale = 0f;
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
            _isPage3Open = true;
         }
         else if (!_isPage3)
         {
            empPanel.SetActive(true);
            _isPage3Open = true;
         }
      }
      else if (_isPage3Open)
      {
         panPanel.SetActive(false);
         _isPage3Open = false;
         if (_isPage4)
         {
            empPanel.SetActive(false);
            sipaPanel.SetActive(true);
            _isPage4Open = true;
         }
         else if (!_isPage4)
         {
            empPanel.SetActive(true);
            _isPage4Open = true;
         }
      }
      else if (_isPage4Open)
      {
         sipaPanel.SetActive(false);
         _isPage4Open = false;
         if (_isPage5)
         {
            empPanel.SetActive(false);
            patinteroPanel.SetActive(true);
            _isPage5Open = true;
         }
         else if (!_isPage5)
         {
            empPanel.SetActive(true);
            _isPage5Open = true;
         }
      }
      else if (_isPage5Open)
      {
         patinteroPanel.SetActive(false);
         _isPage5Open = false;
         if (_isPage6)
         {
            empPanel.SetActive(false);
            pikoPanel.SetActive(true);
            //_isPage6Open = true;
         }
         else if (!_isPage6)
         {
            empPanel.SetActive(true);
            //_isPage6Open = true;
         }
      }
      
   }

   public void CloseMenu()
   {
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      empPanel.SetActive(false);
      sipaPanel.SetActive(false);
      patinteroPanel.SetActive(false);
      pikoPanel.SetActive(false);
      pauseMenu.SetActive(true);
      
   }
}
