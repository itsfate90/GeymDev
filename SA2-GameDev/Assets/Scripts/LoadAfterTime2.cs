using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime2 : MonoBehaviour
{
    
    

    private string sceneNameToLoad;
    private float TimeElapse;

    

    private void Update()
    {
        TimeElapse += Time.deltaTime;
        if (TimeElapse >= 8)
        {
            SceneManager.LoadScene("wagul");
        }
    }
}
