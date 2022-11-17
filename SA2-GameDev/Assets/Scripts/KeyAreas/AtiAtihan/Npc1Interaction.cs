using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Npc1Interaction : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject continuePanel;
    [SerializeField] Image speakerImage;
    [SerializeField] Sprite speakerSprite;

    [SerializeField] GameObject indicatorPanel;
    //[SerializeField] TextMeshProUGUI npcName;
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public bool isPlayerClose;
    public bool isAlreadyStarted;
    public bool isSentenceDone;
    public bool haveAlreadyTalkedTo;

    private int _index;

    private void Start()
    {
        textComponent.text= String.Empty;
        isAlreadyStarted = false;
        haveAlreadyTalkedTo = false;
        indicatorPanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerClose = true;
            if (!haveAlreadyTalkedTo)
            {
                indicatorPanel.SetActive(true);
            }
            else
            {
                indicatorPanel.SetActive(false);
            }
            
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
            indicatorPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isAlreadyStarted && !haveAlreadyTalkedTo)
        {
            indicatorPanel.SetActive(false);
            dialoguePanel.SetActive(true);
            isAlreadyStarted = true;
            haveAlreadyTalkedTo = true;
            StartDialogue();
            Time.timeScale = 0f;
        }
        
        if (Input.GetMouseButtonDown(0) && isSentenceDone)
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
        speakerImage.sprite = speakerSprite;
        //npcName.text = "Enter Name";
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
            dialoguePanel.SetActive(false);
            continuePanel.SetActive(false);
            Time.timeScale = 1f;
            textComponent.text= String.Empty;
        }
    }
}