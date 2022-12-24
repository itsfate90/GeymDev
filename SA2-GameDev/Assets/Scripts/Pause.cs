using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool _isPaused;
    private bool _isCheatPanelOpen;
    private bool _isHelpMenuOpen;
    private bool _isMobile;
    [SerializeField]  GameObject pauseMenu;
    [SerializeField] GameObject cheatMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private AudioSource buttonSoundEffect;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject mobileControls;


    private void Start()
    {
        buttonSoundEffect.Stop();
        Time.timeScale = 1f;
        _isPaused = false;
        _isCheatPanelOpen = false;
        _isHelpMenuOpen = true;
        cheatMenu.SetActive(false);
        pauseMenu.SetActive(false);
        helpMenu.SetActive(false);
        returnButton.SetActive(false);
    }

    void Update()
    {
        
        #if UNITY_STANDALONE_WIN
        _isMobile = false;
        mainMenuButton.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

            if (_isCheatPanelOpen)
            {
                cheatMenu.SetActive(false);
                _isCheatPanelOpen = false;
                Time.timeScale = 0f;
                PauseGame();
               
            }

            if (_isHelpMenuOpen)
            {
                helpMenu.SetActive(false);
                _isHelpMenuOpen = false;
                Time.timeScale = 0f;
                PauseGame();
                
            }
        }
#endif
        #if UNITY_IOS
        _isMobile = true;
        if (_isPaused)
        {
            mainMenuButton.SetActive(false);
        }
        else
        {
            mainMenuButton.SetActive(true);
        }
#endif
        #if UNITY_ANDROID
        _isMobile = true;
        if (_isPaused)
        {
            mainMenuButton.SetActive(false);
            mobileControls.SetActive(false);
        }
        else
        {
            mainMenuButton.SetActive(true);
            mobileControls.SetActive(true);
        }
       
#endif
        
    }

    public void ResumeGame()
    {
        buttonSoundEffect.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;

    }

    void PauseGame()
    {
        _isPaused = true;
        mainMenuButton.SetActive(false);
        buttonSoundEffect.Play();
       pauseMenu.SetActive(true);
       Time.timeScale = 0f;
       

    }

    public void LoadMenu()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        buttonSoundEffect.Play();
        Application.Quit();
        Debug.Log("Quit");
        
    }

    public void Cheat()
    {
        if (_isMobile)
        {
            returnButton.SetActive(true);
        }
        buttonSoundEffect.Play();
        cheatMenu.SetActive(true);
        _isCheatPanelOpen = true;
        pauseMenu.SetActive(false);
    }

    public void Level1()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene("SampleScene");
        pauseMenu.SetActive(false);
    }
    public void Level2()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene("Area2");
        pauseMenu.SetActive(false);
    }
    public void Level3()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene("Area3");
        pauseMenu.SetActive(false);
    }

    public void HelpButton()
    {
        if (_isMobile)
        {
            returnButton.SetActive(true);
        }
        buttonSoundEffect.Play();
        helpMenu.SetActive(true);
        _isHelpMenuOpen = true;
        pauseMenu.SetActive(false);
    }

    public void ReturnButton()
    {
        if (_isMobile)
        {
            returnButton.SetActive(false);
        }
        buttonSoundEffect.Play();
        helpMenu.SetActive(false);
        cheatMenu.SetActive(false);
        _isHelpMenuOpen = false;
        pauseMenu.SetActive(true);
        
    }

    public void PauseButton()
    {
        if (!_isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
            
        }
    }
}
