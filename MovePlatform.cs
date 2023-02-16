using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform topLimit,downLimit;
    
    private float topY, downY;
    private bool facetop = true;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();
        topY = topLimit.position.y;
        downY = downLimit.position.y;
        Destroy(topLimit.gameObject);
        Destroy(downLimit.gameObject);

        rb = GetComponent<Rigidbody2D>();
       transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;//None
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
   void Movement() 
    {
        if (facetop)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1.5f);
            if (transform.position.y > topY)
            {
                facetop = false;
            }

        }else
        {
            rb.velocity = new Vector2(rb.velocity.x,-1.5f);
            if (transform.position.y < downY)
            {
                facetop = true;
            }
        }
        if (Anim.enabled == true)
        {
            transform.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }

    }
    
}
