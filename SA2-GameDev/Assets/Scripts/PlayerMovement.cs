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
    private bool _isMobile;
    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private GameObject joystickPanel;
    
    public Joystick Js;

    private void Start()
    {
#if UNITY_STANDALONE_WIN
    _isMobile = false;
#elif UNITY_IOS || UNITY_ANDROID
        _isMobile = true;

#endif

    }
    

    void Update()
    {
        if (!_isMobile)
        {
            joystickPanel.SetActive(false);
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
      

            if (Input.GetButtonDown("Jump"))
            {   
                JumpKey();
           
            }
        }
        else
        {
            horizontalMove = Js.Horizontal * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
            if (Input.GetButtonDown("Jump"))
            {   
                JumpKey();
           
            }
        }
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
