using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject guidePanelForPc;
    [SerializeField] private GameObject guidePanelForMobile;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject returnButton;
    private bool _isguidePanelOpen;
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _isguidePanelOpen &&!_isMobile)
        {
            guidePanelForPc.SetActive(false);
            _isguidePanelOpen = false;
            mainMenuPanel.SetActive(true);
        }

        if (_isMobile && _isguidePanelOpen)
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
        _isguidePanelOpen = false;
        mainMenuPanel.SetActive(true);
    }
}
