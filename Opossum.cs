using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy

{
   
    public Transform leftLimit, rightLimit;
    private float leftX, rightX;
    private bool faceLeft = true;
    // Start is called before the first frame update
    protected override void Start()
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
        //Movement();
    }


    void Movement()
    {
        if (faceLeft)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-8,rb.velocity.y);

            if (transform.position.x < leftX)
            {

                faceLeft = false;
            }
        }
        else 
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(8,rb.velocity.y );
            if (transform.position.x > rightX)
            {

                faceLeft = true;
            }
        }

    }

     

  
    
}
