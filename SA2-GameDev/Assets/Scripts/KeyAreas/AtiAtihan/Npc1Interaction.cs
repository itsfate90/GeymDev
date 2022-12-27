using System;
using System.Collections;
using Mono.Cecil.Cil;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Npc1Interaction : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject continuePanel;
    [SerializeField] Button talkButton;
    
    [SerializeField] Image speakerImage;
    [SerializeField] Sprite speakerSprite;
    
    //[SerializeField] Image playerImage;
    //[SerializeField] Sprite playerSprite;
    
    

    [SerializeField] GameObject indicatorPanel;
    //[SerializeField] TextMeshProUGUI npcName;
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public bool isPlayerClose;
    public bool isAlreadyStarted;
    public bool isSentenceDone;
    public bool isMobile;
    public bool doubleClicked;
    

    private int _index;

    private void Start()
    {
        #if UNITY_STANDALONE_WIN
        isMobile = false;
        #elif UNITY_ANDROID || UNITY_IOS
        isMobile = true;
#endif
        

        textComponent.text= String.Empty;
        isAlreadyStarted = false;
        indicatorPanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerClose = true;
            if (isMobile && isPlayerClose && !isAlreadyStarted)
            { 
                talkButton.gameObject.SetActive(true);
                talkButton.onClick.AddListener(InteractButton);
            }
            if (isPlayerClose)
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
            if(isMobile && !isPlayerClose || isAlreadyStarted)
            {
                talkButton.gameObject.SetActive(false);
                talkButton.onClick.RemoveListener(InteractButton);
            }
            indicatorPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isAlreadyStarted && !isMobile)
        {
            indicatorPanel.SetActive(false);
            dialoguePanel.SetActive(true);
            isAlreadyStarted = true;
            StartDialogue();
            Time.timeScale = 0f;
        }
        if (Input.anyKey && isSentenceDone)
        {
            
            if (textComponent.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                if (isPlayerClose && isMobile)
                {
                    talkButton.gameObject.SetActive(true);
                    
                }
            }
        }
    }

    void StartDialogue()
    {
        speakerImage.sprite = speakerSprite;
        //playerImage.sprite = playerSprite;
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
            isAlreadyStarted = false;
            indicatorPanel.SetActive(true);
        }
    }

    public void InteractButton()
    {
        talkButton.gameObject.SetActive(false);
        indicatorPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        isAlreadyStarted = true;
        StartDialogue();
        Time.timeScale = 0f;
        
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
}