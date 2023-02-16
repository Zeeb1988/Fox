using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemy
{
   
    public Transform topLimit, lowLimit;
    private float topY, lowY;
    private bool faceTop = true;
    public AudioSource flyVoice;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
        topY = topLimit.position.y;
        lowY = lowLimit.position.y;
        Destroy(topLimit.gameObject);
        Destroy(lowLimit.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
            Movement();
       
    }


    void Movement()
    {
        if (faceTop)
        {
           rb.velocity = new Vector2(rb.velocity.x,1.5f); 
            
            if (transform.position.y > topY)
            {

                faceTop = false;
            }
        }else
        {
            rb.velocity = new Vector2(rb.velocity.x, -1.5f);

            if (transform.position.y < lowY)
            {

                faceTop = true;
            }
        }
    }

    public void Voice() { flyVoice.Play(); }

}
