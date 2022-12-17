using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_scriptSFX : MonoBehaviour

{
    [SerializeField] private AudioSource GoalSFX;
    bool goalActive=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Player"){
            if(goalActive==false){
            goalActive=true;
            if(goalActive==true){
            GoalSFX.Play();
            }
        }
           
        }
    }
 
}
