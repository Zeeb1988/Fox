using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : MonoBehaviour
{
    
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
       
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (collision.gameObject.tag=="Players")
        {
            Anim.enabled = true;
            player.hurtVoice.Play(); 
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
    

}
