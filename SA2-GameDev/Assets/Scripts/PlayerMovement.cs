using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 150;
    bool jump = false;
    //private bool _isGround;
    [SerializeField] private AudioSource jumpSoundEffect;

  

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

        if (Input.GetButtonDown("Jump"))
        {   
            jump = true;
           
            
                jumpSoundEffect.Play();
            
            animator.SetBool("IsJumping", true);
           
        }
    }

   
    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
       
    }
   


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
