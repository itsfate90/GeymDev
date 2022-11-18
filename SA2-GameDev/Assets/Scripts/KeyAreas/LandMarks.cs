using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class LandMarks : MonoBehaviour
{
    [SerializeField] private GameObject welcomePanel;
    public TextMeshProUGUI textComponent;
    private int _index;
    public string[] lines;
    public float textSpeed;
   

    private void Start()
    {
        welcomePanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            textComponent.text = String.Empty;
            StartWelcome();
            welcomePanel.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            welcomePanel.SetActive(false);
        }
    }

    private void StartWelcome()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
}