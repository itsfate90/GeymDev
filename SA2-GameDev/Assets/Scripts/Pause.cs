using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool _isPaused;
    private bool _isCheatPanelOpen;
    private bool _isHelpMenuOpen;
    [SerializeField]  GameObject pauseMenu;
    [SerializeField] GameObject cheatMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private AudioSource buttonSoundEffect;
    [SerializeField] private GameObject mainMenuButton;


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
    }

    void Update()
    {
        
        #if UNITY_STANDALONE_WIN
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
        if (_isPaused)
        {
            mainMenuButton.SetActive(false);
        }
        else
        {
            mainMenuButton.SetActive(true);
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
        mainMenuButton.SetActive(false);
        buttonSoundEffect.Play();
       pauseMenu.SetActive(true);
       Time.timeScale = 0f;
       _isPaused = true;

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
        buttonSoundEffect.Play();
        helpMenu.SetActive(true);
        _isHelpMenuOpen = true;
        pauseMenu.SetActive(false);
    }

    public void ReturnButton()
    {
        buttonSoundEffect.Play();
        helpMenu.SetActive(false);
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
