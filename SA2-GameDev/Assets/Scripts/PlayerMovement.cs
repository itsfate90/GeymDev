using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 150;
     public ParticleSystem dust;
    bool jump = false;
    //private bool _isGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private GameObject joystickPanel;
    public Joystick Js;

   
    
    

    void Update()
    {
#if UNITY_STANDALONE_WIN
            Debug.Log("stand alone windows");
            joystickPanel.SetActive(false);
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
             animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

            if (Input.GetButtonDown("Jump"))
            {   
                JumpKey();
           
            }
#endif
        
#if UNITY_IOS
        Debug.Log("IOS");
        joystickPanel.SetActive(true);
        horizontalMove = Js.Horizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

        if (Input.GetButtonDown("Jump"))
        {   
            JumpKey();
           
        }
        
#endif
#if UNITY_ANDROID
        Debug.Log("Android");
        joystickPanel.SetActive(true);
        horizontalMove = Js.Horizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

        if (Input.GetButtonDown("Jump"))
        {   
            JumpKey();
           
        }
#endif

    }

    public void JumpKey()
    {
        jump = true;
        jumpSoundEffect.Play();
        animator.SetBool("IsJumping", true);
    }

   
    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
             CreateDust();
        
       
    }
   


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        
       
        jump = false;
    }
     void CreateDust(){
        dust.Play();
    }
   
}
