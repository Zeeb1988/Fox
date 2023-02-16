using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool faceLeft = true;
    public Transform leftLimit, rightLimit;
    private float leftX, rightX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftX = leftLimit.position.x;
        rightX = rightLimit.position.x;
        Destroy(leftLimit.gameObject);
        Destroy(rightLimit.gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (faceLeft)
        {
            rb.velocity = new Vector2(-1.5f, rb.velocity.y);
            if (transform.position.x < leftX)
            {
                faceLeft = false;
            }
        }
        else {

            rb.velocity = new Vector2(1.5f,rb.velocity.y);
            if (transform.position.x > rightX)
            {
                faceLeft = true;
            }
        
        }

    }

}
