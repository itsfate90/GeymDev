using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_trap : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bullet;
    float timebetween;
    public float starttimebetween;
    // Start is called before the first frame update
    void Start()
    {
        timebetween=starttimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebetween<=0)
        {
            Instantiate(bullet,firepoint.position,firepoint.rotation);
            timebetween= starttimebetween;
        }
        else
        {
            timebetween-=Time.deltaTime;
        }
    }
}
