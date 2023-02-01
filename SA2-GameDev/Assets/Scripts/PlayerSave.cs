using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
  public float x, y, z;

  private void Start()
  {
    if(PlayerPrefs.GetInt("Saved") == 1)
    {
      x = PlayerPrefs.GetFloat("x");
      y = PlayerPrefs.GetFloat("y");
      z = PlayerPrefs.GetFloat("z");
      transform.position = new Vector3(x, y, z);
      PlayerPrefs.SetInt("TimeToLoad",0);
      PlayerPrefs.Save();
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

    //x = PlayerPrefs.GetFloat("x");
    // y = PlayerPrefs.GetFloat("y");
    //z = PlayerPrefs.GetFloat("z");

    //Vector3 loadPosition = new Vector3(x, y, z);
    //transform.position = loadPosition;



  }
}
