using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPLatform : MonoBehaviour
{
    private float fallDelay = 0.5f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collsion){
        if (collsion.gameObject.CompareTag("Player")){
            StartCoroutine(Fall());
        }
    }
   
   private IEnumerator Fall(){
    yield return new WaitForSeconds(fallDelay);
    rb.bodyType = RigidbodyType2D.Dynamic;
    Destroy(gameObject, destroyDelay);
   }
}
