using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class PaperMechanic : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject continuePanel;
    [SerializeField] Image speakerImage;
    [SerializeField] Sprite speakerSprite;
    //[SerializeField] TextMeshProUGUI npcName;
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public bool isPlayerClose;
    public bool alreadyCollected;
    public bool isDone;
    

    private int _index;

    private void Start()
    {
        textComponent.text= String.Empty;
        alreadyCollected = false;
        isDone = false;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        isPlayerClose = col.CompareTag("Player");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
        }
    }

    private void Update()
    {
        if (isPlayerClose && !alreadyCollected)
        {
            dialoguePanel.SetActive(true);
            alreadyCollected = true;
            StartDialogue();
            Time.timeScale = 0f;
            
        }
        
        if (Input.anyKey && isDone || (Input.GetKeyDown(0) && isDone))
        {
            
            if (textComponent.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                continuePanel.SetActive(false);
            }
        }
    }

    void StartDialogue()
    {
        speakerImage.sprite = speakerSprite;
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            isDone = false;
            continuePanel.SetActive(false);
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
            isDone = true;
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