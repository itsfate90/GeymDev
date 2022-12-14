using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject mainMenuPanel;
    private bool _isguidePanelOpen;

    private void Start()
    {
        guidePanel.SetActive(false);
        _isguidePanelOpen = false;
        mainMenuPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game is Closed");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ControlButton()
    {
        mainMenuPanel.SetActive(false);
        guidePanel.SetActive(true);
        _isguidePanelOpen = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _isguidePanelOpen)
        {
            guidePanel.SetActive(false);
            _isguidePanelOpen = false;
            mainMenuPanel.SetActive(true);
        }
    }

    public void ReturnButton()
    {
        guidePanel.SetActive(false);
        _isguidePanelOpen = false;
        mainMenuPanel.SetActive(true);
    }
}
