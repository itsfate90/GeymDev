using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool _isPaused;
    private bool _isCheatPanelOpen;
    [SerializeField]  GameObject pauseMenu;
    [SerializeField] GameObject cheatMenu;


    private void Start()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        _isCheatPanelOpen = false;
        cheatMenu.SetActive(false);
        pauseMenu.SetActive(false);
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
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
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
}
