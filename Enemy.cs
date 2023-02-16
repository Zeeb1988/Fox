using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator Anim;
    protected Rigidbody2D rb;
    protected Collider2D circle;
    protected virtual void Start() 
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<Collider2D>();
        transform.DetachChildren();
        
    }

    public void DeathAnimation()
    {


        Anim.SetTrigger("death");


    }
    public void Death()
    {

        Destroy(gameObject);

    }
    public void DestroyAnything()
    {

        circle.enabled = false;
        //Destroy(GetComponent<Rigidbody2D>());

    }

}
