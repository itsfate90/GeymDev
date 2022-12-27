using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StoryScene : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject continuePanelForPc;
    [SerializeField] GameObject continuePanelForMobile;
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public bool isSentenceDone;
    public bool isMobile;

    private int _index;

    private void Start()
    {
        #if UNITY_STANDALONE_WIN
        isMobile = false;
        #elif UNITY_IOS || UNITY_ANDROID
        isMobile = true;
        #endif
        textComponent.text= String.Empty;
        continuePanelForMobile.SetActive(false);
        continuePanelForPc.SetActive(false);
        StartDialogue();
    }

    

    private void Update()
    {
       
        if (Input.anyKey && isSentenceDone)
        {
            
            if (textComponent.text == lines[_index])
            {
                NextLine();
                
            }
            else
            {
                StopAllCoroutines();
                
            }
        }
    }

    void StartDialogue()
    {
        _index = 0;
        
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            isSentenceDone = false;
            continuePanelForPc.SetActive(false);
            continuePanelForMobile.SetActive(false);
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
            isSentenceDone = true;
            if (isMobile)
            {
                continuePanelForMobile.SetActive(true);
            }
            else
            {
                continuePanelForPc.SetActive(true);
            }
        }
    }

    void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}