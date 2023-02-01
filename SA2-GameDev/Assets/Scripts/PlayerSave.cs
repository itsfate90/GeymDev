using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerSave : MonoBehaviour
{
  public float x, y, z;
  [SerializeField] private GameObject startButton;
  [SerializeField] private GameObject loadButton;
  [SerializeField] private GameObject resetButton;

  private void Start()
  {
    if(PlayerPrefs.GetInt("Saved") == 1)
    {
      //startButton.SetActive(false);
      //loadButton.SetActive(true);
      //resetButton.SetActive(true);
      x = PlayerPrefs.GetFloat("x");
      y = PlayerPrefs.GetFloat("y");
      z = PlayerPrefs.GetFloat("z");
      transform.position = new Vector3(x, y, z);
      PlayerPrefs.SetInt("TimeToLoad",0);
      PlayerPrefs.Save();
    }
    else
    {
      //startButton.SetActive(true);
      //loadButton.SetActive(false);
      //resetButton.SetActive(false);
    }
    Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
    
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
    Debug.Log("Saved!");
   PlayerPrefs.SetFloat("x",transform.position.x);
   PlayerPrefs.SetFloat("y", transform.position.y);
   PlayerPrefs.SetFloat("z", transform.position.z);
   PlayerPrefs.SetInt("Saved", 1);
   PlayerPrefs.Save();
    
  }
  public void Load()
  {
    
    PlayerPrefs.Save();
    SceneManager.LoadScene("SampleScene");
    
  }

  public void ResetData()
  {
    PlayerPrefs.DeleteAll();
    loadButton.SetActive(false);
    startButton.SetActive(true);
  }
}
