using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{   [SerializeField] float moveSpeed=1f;

    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myRigidBody.velocity=new Vector2(moveSpeed,0f);
        }
        else{
             myRigidBody.velocity=new Vector2(-moveSpeed,0f);
        }
    }
    private bool IsFacingRight(){
        return transform.localScale.x>Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision){
       transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
   
}
