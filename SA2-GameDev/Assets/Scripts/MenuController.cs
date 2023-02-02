using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject guidePanelForPc;
    [SerializeField] private GameObject guidePanelForMobile;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject achievementPanel;
    private bool _isguidePanelOpen;
    private bool _isachievementPanelOpen;
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
        guidePanelForPc.SetActive(false);
        guidePanelForMobile.SetActive(false);
        returnButton.SetActive(false);
        achievementPanel.SetActive(false);
        _isguidePanelOpen = false;
        _isachievementPanelOpen = false;
        mainMenuPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game is Closed");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void ControlButton()
    {
        mainMenuPanel.SetActive(false);
        _isguidePanelOpen = true;
        if (_isMobile)
        {
            guidePanelForMobile.SetActive(true);
        }
        else
        {
            guidePanelForPc.SetActive(true);
        }
    }

    public void AchievementButton()
    {
        mainMenuPanel.SetActive(false);
        achievementPanel.SetActive(true);
        _isachievementPanelOpen = true;
       

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isguidePanelOpen && !_isMobile)
        {
            guidePanelForPc.SetActive(false);
            _isguidePanelOpen = false;
            mainMenuPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _isachievementPanelOpen && !_isMobile)
        {
            
            mainMenuPanel.SetActive(true);
            _isguidePanelOpen = false;
            achievementPanel.SetActive(false);
        }

        if (_isMobile && _isguidePanelOpen)
        {
            returnButton.SetActive(true);
        }

        if (_isMobile && _isachievementPanelOpen)
        {
            returnButton.SetActive(true);    
        }
        else
        {
            returnButton.SetActive(false);
        }
    }

    public void ReturnButton()
    {
        guidePanelForMobile.SetActive(false);
        achievementPanel.SetActive(false);
        _isguidePanelOpen = false;
        _isachievementPanelOpen = false;
        mainMenuPanel.SetActive(true);
    }

}
