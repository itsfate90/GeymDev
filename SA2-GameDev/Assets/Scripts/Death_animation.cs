using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_animation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource DeathSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
      private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Enemy")){
        anim.Play("Crying_anim");
           DeathSoundEffect.Play();  
        }
        else  if (collision.CompareTag("FallDetector"))
        {
           anim.Play("Crying_anim");
            DeathSoundEffect.Play();
        }
        
        
    }
}
