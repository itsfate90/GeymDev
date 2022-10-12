using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;
    public float speedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        playerPos=player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        if(Vector2.Distance(transform.position, playerPos.position)<distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position,
            speedEnemy *Time.deltaTime);
        }
        else
        {
             if(Vector2.Distance(transform.position, currentPos)<=0)
             {

             }
             else
             {
                 transform.position = Vector2.MoveTowards(transform.position, currentPos,
            speedEnemy *Time.deltaTime);
             }
        }
    }
    private void flip(){
        if(transform.position.x>player.transform.position.x){
            transform.rotation=Quaternion.Euler(0,0,0);
        }
        else{
            transform.rotation=Quaternion.Euler(0,180,0);
        }
    }
}
