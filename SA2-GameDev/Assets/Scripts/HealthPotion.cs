using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthPotion : MonoBehaviour
{
    private bool _hasAlreadyUsed;
    
    private void Start()
    {
        
        if (PlayerPrefs.GetInt("SavePotion") == 1)
        {
            _hasAlreadyUsed = (PlayerPrefs.GetInt("Potion")!=0);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && HealthCount.Health <= 4 && !_hasAlreadyUsed)
        {
            HealthCount.Health += 1;
            Debug.Log("you picked up a HP");
            _hasAlreadyUsed = true;
        }
    }

    public void SavePotionState()
    {
        PlayerPrefs.SetInt("SavePotion", 1);
        PlayerPrefs.SetInt("Potion", _hasAlreadyUsed ? 1 : 0);
    }

   
   
}
