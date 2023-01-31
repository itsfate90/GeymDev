using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && HealthCount.Health <= 4)
            HealthCount.Health += 1;
        Debug.Log("you picked up a HP");
    }
}
