using System;
using System.Collections;
using UnityEngine;
using TMPro;


public class Npc1Interaction : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool isPlayerClose;
    public bool isAlreadyStarted;
   

    private int _index;

    private void Start()
    {
        textComponent.text= String.Empty;
        
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
        if (isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isAlreadyStarted)
        {
            dialoguePanel.SetActive(true);
            isAlreadyStarted = true;
            StartDialogue();
        }
        
        if (Input.GetMouseButtonDown(0))
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
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
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
            

        }
    }
}