using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StoryScene : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject continuePanel;
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public bool isSentenceDone;

    private int _index;

    private void Start()
    {
        textComponent.text= String.Empty;
        continuePanel.SetActive(false);
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
            continuePanel.SetActive(false);
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
            isSentenceDone = true;
            continuePanel.SetActive(true);
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