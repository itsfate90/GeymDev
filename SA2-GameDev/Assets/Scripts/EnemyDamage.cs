using System;
using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private bool isGhostOver;

    private void Start()
    {
        isGhostOver = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.isTrigger = false;
            HealthCount.Health--;
            StartCoroutine(countdown());
            if (isGhostOver)
            {
                col.isTrigger = true;
            }
           
        }
       
    }

    IEnumerator countdown()
    {
        isGhostOver = false;
        yield return new WaitForSeconds(2);
        isGhostOver = true;
    }
}

