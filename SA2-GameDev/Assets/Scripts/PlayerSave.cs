using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class PlayerSave : MonoBehaviour
{
  
  public float x, y, z;
  [SerializeField] private GameObject startButton;
  [SerializeField] private GameObject loadButton;
  [SerializeField] private GameObject resetButton;
  

  private void Start()
  {
   
    Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
    if(PlayerPrefs.GetInt("Saved1") == 1)
    {
      if (sceneName == "SampleScene")
      {
        x = PlayerPrefs.GetFloat("x1");
        y = PlayerPrefs.GetFloat("y1");
        z = PlayerPrefs.GetFloat("z1");
        transform.position = new Vector3(x, y, z);
        PlayerPrefs.Save();
      }

      else if (PlayerPrefs.GetInt("Saved2") == 1)
      {
        if (sceneName == "Area2")
        {
          x = PlayerPrefs.GetFloat("x2");
          y = PlayerPrefs.GetFloat("y2");
          z = PlayerPrefs.GetFloat("z2");
          transform.position = new Vector3(x, y, z);
          PlayerPrefs.Save();
        }
      }
      else if (PlayerPrefs.GetInt("Saved3") == 1)
      {
        if (sceneName == "Area3")
        {
          x = PlayerPrefs.GetFloat("x3");
          y = PlayerPrefs.GetFloat("y3");
          z = PlayerPrefs.GetFloat("z3");
          transform.position = new Vector3(x, y, z);
          PlayerPrefs.Save();
        }
      }

   
    }
    
    if(sceneName == "MainMenu") 
    {
      if (PlayerPrefs.GetInt("Saved") == 1)
      {
        startButton.SetActive(false);
        loadButton.SetActive(true);
        resetButton.SetActive(true);
      }
      else
      {
        startButton.SetActive(true);
        loadButton.SetActive(false);
        resetButton.SetActive(false);
      }
    }
  }


  public void position_save()
  {
    PlayerPrefs.SetInt("Saved",1);
    Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
    
    Debug.Log("Saved!");
    if (sceneName == "SampleScene")
    {
      PlayerPrefs.SetInt("Saved1", 1);
      PlayerPrefs.SetFloat("x1",transform.position.x);
      PlayerPrefs.SetFloat("y1", transform.position.y);
      PlayerPrefs.SetFloat("z1", transform.position.z);
    }

    else if (sceneName == "Area2")
    {
      PlayerPrefs.SetInt("Saved2", 1);
      PlayerPrefs.SetFloat("x2",transform.position.x);
      PlayerPrefs.SetFloat("y2", transform.position.y);
      PlayerPrefs.SetFloat("z2", transform.position.z);
    }
    else if(sceneName == "Area3")
    {
      PlayerPrefs.SetInt("Saved3", 1);
      PlayerPrefs.SetFloat("x3",transform.position.x);
      PlayerPrefs.SetFloat("y3",transform.position.y);
      PlayerPrefs.SetFloat("z3",transform.position.z);
    }
    
   
   
   PlayerPrefs.SetInt("savedScene", SceneManager.GetActiveScene().buildIndex);
   PlayerPrefs.Save();
    
  }
  public void Load()
  {
    SceneManager.LoadScene(PlayerPrefs.GetInt("savedScene"));
   
    PlayerPrefs.Save();
   

  }

  public void ResetData()
  {
    PlayerPrefs.DeleteAll();
    loadButton.SetActive(false);
    resetButton.SetActive(false);
    startButton.SetActive(true);
  }
}
