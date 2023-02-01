using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenInventory : MonoBehaviour
{
   private bool _isPage1Collected;
   private bool _isPage2Collected;
   private bool _isPage3Collected;

   private bool _isPage4Collected;
   private bool _isPage5Collected;
   private bool _isPage6Collected;
   
   private bool _isPage7Collected;
   private bool _isPage8Collected;
   private bool _isPage9Collected;

   private bool _isPage10Collected;

   private bool _isPage1Open;
   private bool _isPage2Open;
   private bool _isPage3Open;

   private bool _isPage4Open;
   private bool _isPage5Open;
   private bool _isPage6Open;
   
   private bool _isPage7Open;
   private bool _isPage8Open;
   private bool _isPage9Open;

   //private bool _isPage10Open;
   
   private bool _isOpenInventoryOpen;
  

   [SerializeField] private GameObject atiPanel;
   [SerializeField] private GameObject florPanel;
   [SerializeField] private GameObject panPanel;
   [SerializeField] private GameObject empPanel;
   [SerializeField] private GameObject pauseMenu;
   [SerializeField] private GameObject sipaPanel;
   [SerializeField] private GameObject patinteroPanel;
   [SerializeField] private GameObject pikoPanel;
   [SerializeField] private GameObject manoPanel;
   [SerializeField] private GameObject bayanihanPanel;
   [SerializeField] private GameObject haranaPanel;
   [SerializeField] private GameObject pabasaPanel;
   
   
   

   private void Start()
   {
      if (PlayerPrefs.GetInt("SavePage") == 1)
      {
         _isPage1Collected = (PlayerPrefs.GetInt("p1") != 0);
         _isPage2Collected = (PlayerPrefs.GetInt("p2") != 0);
         _isPage3Collected = (PlayerPrefs.GetInt("p3") != 0);
         _isPage4Collected = (PlayerPrefs.GetInt("p4") != 0);
         _isPage5Collected = (PlayerPrefs.GetInt("p5") != 0);
         _isPage6Collected = (PlayerPrefs.GetInt("p6") != 0);
         _isPage7Collected = (PlayerPrefs.GetInt("p7") != 0);
         _isPage8Collected = (PlayerPrefs.GetInt("p8") != 0);
         _isPage9Collected = (PlayerPrefs.GetInt("p9") != 0);
         _isPage10Collected = (PlayerPrefs.GetInt("p10") != 0);
         PlayerPrefs.Save();
      }
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      sipaPanel.SetActive(false);
      patinteroPanel.SetActive(false);
      pikoPanel.SetActive(false);
      empPanel.SetActive(false);
      manoPanel.SetActive(false);
      bayanihanPanel.SetActive(false);
      haranaPanel.SetActive(false);
      pabasaPanel.SetActive(false);
      _isOpenInventoryOpen = false;

      Scene currentScene = SceneManager.GetActiveScene();
      string sceneName = currentScene.name;

      //if (sceneName == "SampleScene")
     //{
        // _isPage1Collected = false;
         //_isPage2Collected = false;
         //_isPage3Collected = false;
      //}
      //if (sceneName == "Area2")
      //{
         //_isPage1Collected = true;
         //_isPage2Collected = true;
         //_isPage3Collected = true;
     // }
     // else if (sceneName == "Area3")
      //{
        // _isPage1Collected = true;
         //_isPage2Collected = true;
         //_isPage3Collected = true;
         //_isPage4Collected = true;
         //_isPage5Collected = true;
         //_isPage6Collected = true;
     // }
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("TornPaper"))
      {
         _isPage1Collected = true;
      }

      if (col.CompareTag("TornPaper2"))
      {
         _isPage2Collected = true;
      }

      if (col.CompareTag("TornPaper3"))
      {
         _isPage3Collected = true;
      }

      if (col.CompareTag("TornPaper4"))
      {
         _isPage4Collected = true;
      }

      if (col.CompareTag("TornPaper5"))
      {
         _isPage5Collected = true;
      }

      if (col.CompareTag("TornPaper6"))
      {
         _isPage6Collected = true;
      }
      if (col.CompareTag("TornPaper7"))
      {
         _isPage7Collected = true;
      }
      if (col.CompareTag("TornPaper8"))
      {
         _isPage8Collected = true;
      }
      if (col.CompareTag("TornPaper9"))
      {
         _isPage9Collected = true;
      }

      if (col.CompareTag("TornPaper10"))
      {
         _isPage10Collected = true;
      }
   }

   public  void OpenBook()
   {
      Time.timeScale = 0f;
      pauseMenu.SetActive(false);
      _isOpenInventoryOpen = true;
      if (_isPage1Collected)
      {
         atiPanel.SetActive(true);
         _isPage1Open = true;
      }
      else if (!_isPage1Collected)
      {
         empPanel.SetActive(true);
         _isPage1Open = true;
      }
   }

   public void NextPage1()
   {
      _isOpenInventoryOpen = true;
      
      atiPanel.SetActive(false);
      if (_isPage1Open)
      {
         _isPage1Open = false;
         if (_isPage2Collected)
         {
            empPanel.SetActive(false);
            florPanel.SetActive(true);
            _isPage2Open = true;
            
         }
         else if(!_isPage2Collected)
         {
            empPanel.SetActive(true);
            _isPage2Open = true;
         }
         
      }
      else if(_isPage2Open)
      {
         florPanel.SetActive(false);
         _isPage2Open = false;
         if (_isPage3Collected)
         {
            empPanel.SetActive(false);
            panPanel.SetActive(true);
            _isPage3Open = true;
         }
         else if (!_isPage3Collected)
         {
            empPanel.SetActive(true);
            _isPage3Open = true;
         }
      }
      else if (_isPage3Open)
      {
         panPanel.SetActive(false);
         _isPage3Open = false;
         if (_isPage4Collected)
         {
            empPanel.SetActive(false);
            sipaPanel.SetActive(true);
            _isPage4Open = true;
         }
         else if (!_isPage4Collected)
         {
            empPanel.SetActive(true);
            _isPage4Open = true;
         }
      }
      else if (_isPage4Open)
      {
         sipaPanel.SetActive(false);
         _isPage4Open = false;
         if (_isPage5Collected)
         {
            empPanel.SetActive(false);
            patinteroPanel.SetActive(true);
            _isPage5Open = true;
         }
         else if (!_isPage5Collected)
         {
            empPanel.SetActive(true);
            _isPage5Open = true;
         }
      }
      else if (_isPage5Open)
      {
         patinteroPanel.SetActive(false);
         _isPage5Open = false;
         if (_isPage6Collected)
         {
            empPanel.SetActive(false);
            pikoPanel.SetActive(true);
            _isPage6Open = true;
         }
         else if (!_isPage6Collected)
         {
            empPanel.SetActive(true);
            _isPage6Open = true;
         }
      }
      else if (_isPage6Open)
      {
         pikoPanel.SetActive(false);
         _isPage6Open = false;
         if (_isPage7Collected)
         {
            empPanel.SetActive(false);
            manoPanel.SetActive(true);
            _isPage7Open = true;

         }
         else if (!_isPage7Collected)
         {
            empPanel.SetActive(true);
            _isPage7Open = true;

         }
      }
      else if (_isPage7Open)
      {
         manoPanel.SetActive(false);
         _isPage7Open = false;
         if (_isPage8Collected)
         {
            empPanel.SetActive(false);
            bayanihanPanel.SetActive(true);
            _isPage8Open = true;

         }
         else if (!_isPage8Collected)
         {
            empPanel.SetActive(true);
            _isPage8Open = true;

         }
      }
      else if (_isPage8Open)
      {
         bayanihanPanel.SetActive(false);
         _isPage8Open = false;
         if (_isPage9Collected)
         {
            empPanel.SetActive(false);
            haranaPanel.SetActive(true);
            _isPage9Open = true;

         }
         else if (!_isPage9Collected)
         {
            empPanel.SetActive(true);
            _isPage9Open = true;

         }
      }
      else if (_isPage9Open)
      {
         haranaPanel.SetActive(false);
         _isPage9Open = false;
         if (_isPage10Collected)
         {
            empPanel.SetActive(false);
            pabasaPanel.SetActive(true);
            //_isPage1Open = true;

         }
         else if (!_isPage10Collected)
         {
            empPanel.SetActive(true);
            //_isPage10Open = true;

         }
      }
      
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape) && _isOpenInventoryOpen)
      {
         CloseALlPanel();
         _isOpenInventoryOpen = false;
         pauseMenu.SetActive(true);
      }
   }

   public void CloseMenu()
   {
      CloseALlPanel();
      _isOpenInventoryOpen = false;
      pauseMenu.SetActive(true);
      
   }

   private void CloseALlPanel()
   {
      atiPanel.SetActive(false);
      florPanel.SetActive(false);
      panPanel.SetActive(false);
      empPanel.SetActive(false);
      sipaPanel.SetActive(false);
      patinteroPanel.SetActive(false);
      pikoPanel.SetActive(false);
      manoPanel.SetActive(false);
      haranaPanel.SetActive(false);
      pabasaPanel.SetActive(false);
      bayanihanPanel.SetActive(false);
   }

   public void Save_page()
   {
      int value;
      PlayerPrefs.SetInt("SavePage", 1);
      PlayerPrefs.SetInt("p1", (_isPage1Collected ? 1 : 0));
      PlayerPrefs.SetInt("p2", (_isPage2Collected ? 1 : 0));
      PlayerPrefs.SetInt("p3", (_isPage3Collected ? 1 : 0));
      PlayerPrefs.SetInt("p4", (_isPage4Collected ? 1 : 0));
      PlayerPrefs.SetInt("p5", (_isPage5Collected ? 1 : 0));
      PlayerPrefs.SetInt("p6", (_isPage6Collected ? 1 : 0));
      PlayerPrefs.SetInt("p7", (_isPage7Collected ? 1 : 0));
      PlayerPrefs.SetInt("p8", (_isPage8Collected ? 1 : 0));
      PlayerPrefs.SetInt("p9", (_isPage9Collected ? 1 : 0));
      PlayerPrefs.SetInt("p10", (_isPage10Collected ? 1 : 0));
     PlayerPrefs.Save();
     
   }
}
