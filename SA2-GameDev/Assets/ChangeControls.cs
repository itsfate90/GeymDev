
using UnityEngine;

public class ChangeControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject leftPanel;
    [SerializeField] private GameObject rightPanel;

    private bool _isOnMobileControls;
    void Start()
    {
        _isOnMobileControls = false;
        leftPanel.SetActive(false);
        rightPanel.SetActive(false);
    }
    public void ChangeMode()
    {
        if (!_isOnMobileControls)
        {
            OpenAllPanels();
            _isOnMobileControls = true;
        }
        else if (_isOnMobileControls)
        {
            CloseAllPanels();
            _isOnMobileControls = false;
        }
    }

    private void CloseAllPanels()
    {
        leftPanel.SetActive(false);
        rightPanel.SetActive(false);
    }

    private void OpenAllPanels()
    {
        leftPanel.SetActive(true);
        rightPanel.SetActive(true);
    }
}
