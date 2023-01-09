using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{ 
    void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MainMenu();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
