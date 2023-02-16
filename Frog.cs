using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    
    public LayerMask floor;
    public AudioSource jumpVoice;
   
    public Transform leftLimit, rightLimit;
    private float leftX, rightX;

    private bool faceLeft = true;
    // Start is called before the first frame update
    protected  override void Start()
    {
        
        base.Start();
     
        leftX = leftLimit.position.x;
        rightX = rightLimit.position.x;
        
        Destroy(leftLimit.gameObject);
        Destroy(rightLimit.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        switchAnim();
    }

    void Movement()
    {
        if (faceLeft)
        {

            if ( circle.IsTouchingLayers(floor) )
            {
                
                rb.velocity = new Vector2(-4, 10);
                Anim.SetBool("jumping",true);
                
                
                if (transform.position.x < leftX)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    faceLeft = false;
                    
                    rb.velocity = new Vector2(0, 0);
                }
            }

        } else if ( circle.IsTouchingLayers(floor) )

           {
            Anim.SetBool("jumping", true);
            rb.velocity = new Vector2(4,10);
            
            if (transform.position.x > rightX)
                {
                  transform.localScale = new Vector3(1, 1, 1);
                  faceLeft = true;
               
                  rb.velocity = new Vector2(0, 0);

                 }
           }
          
    }
    void switchAnim() 
    {
        if (Anim.GetBool("jumping") && rb.velocity.y < 0.1f)
        {
            Anim.SetBool("jumping", false);
            Anim.SetBool("falling", true);
        } else if (circle.IsTouchingLayers(floor))
        {
            Anim.SetBool("falling", false);

        } 
        
    }
    public void Voice() { jumpVoice.Play(); }

    
    
}
