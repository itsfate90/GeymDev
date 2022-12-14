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


    private void Start()
    {
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
                pauseMenu.SetActive(true);
               
            }

            if (_isHelpMenuOpen)
            {
                helpMenu.SetActive(false);
                _isHelpMenuOpen = false;
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                
            }
        }
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;

    }

    void PauseGame()
    {
       pauseMenu.SetActive(true);
       Time.timeScale = 0f;
       _isPaused = true;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        
    }

    public void Cheat()
    {
        
        cheatMenu.SetActive(true);
        _isCheatPanelOpen = true;
    }

    public void Level1()
    {
        SceneManager.LoadScene("SampleScene");
        pauseMenu.SetActive(false);
    }
    public void Level2()
    {
        SceneManager.LoadScene("Area2");
        pauseMenu.SetActive(false);
    }
    public void Level3()
    {
        SceneManager.LoadScene("Area3");
        pauseMenu.SetActive(false);
    }

    public void HelpButton()
    {
        helpMenu.SetActive(true);
        _isHelpMenuOpen = true;
        pauseMenu.SetActive(false);
    }

    public void ReturnButton()
    {
        helpMenu.SetActive(false);
        _isHelpMenuOpen = false;
        pauseMenu.SetActive(true);
        
    }
}
