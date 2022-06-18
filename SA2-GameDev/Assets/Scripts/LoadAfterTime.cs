using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour
{
    

    private string sceneNameToLoad;
    private float TimeElapse;

    private void Update()
    {
        TimeElapse += Time.deltaTime;
        if (TimeElapse >= 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    

    
}
