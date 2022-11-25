using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    private Animator anim;
    public bool switch1=false;
    [SerializeField] private AudioSource switchSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        anim.Play("Crank_on");
        if(switch1==false){
            switch1=true;
            if(switch1==true){
            switchSoundEffect.Play();
            }
        }
        
    }
}
