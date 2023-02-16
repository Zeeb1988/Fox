using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isHurt = false;

   
    public  float speed;
    public float jumpForce;
    public LayerMask floor;
    
    public Collider2D circle;
    public Collider2D capsule;
    public int CherryGoal;
    public Text CherryNumbers;
    public int GemGoal;
    public Text GemNumbers;

    public AudioSource jumpVoice;
    public AudioSource runVoice;
    public AudioSource goalVoice;
    public AudioSource hurtVoice;
    public AudioSource bgm;
    public AudioSource deadVoice;

    public Transform pointCheck;
    public GameObject Blood1;
    public GameObject Blood2;
    public GameObject Blood3;
    public GameObject gameOver;
    public GameObject player;
    //protected int goal;
    private int BLOOD = 3;
    private bool isPressed;
    // Start is called before the first frame update
      void Start()
    {
         
       rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
 
    void Update()
    {
        CherryNumbers.text = " " + CherryGoal.ToString();
        GemNumbers.text = " " + GemGoal.ToString();
        //½ÇÉ«°´¼ü¼àÌý
        if (!isHurt)
        {

            if (Input.GetButtonDown("Jump") && circle.IsTouchingLayers(floor))
            {
                isPressed = true;


            }
            
            Crouch();

        }
    }
     void FixedUpdate()
    {
        
        if (!isHurt)
        {
            Movement();
            if (isPressed) { Jump(); }
            
        }
       
          SwitchAnimation();
        

    }
    //½ÇÉ«Ë®Æ½ÖáÒÆ¶¯
    void Movement() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float face = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed /** Time.fixedDeltaTime*/ , rb.velocity.y);

        if (circle.IsTouchingLayers(floor))
        {
           
            anim.SetFloat("running", Mathf.Abs(face));//anim.SetInteger();
            
        }
        else {
            
            anim.SetFloat("running", 3);
            anim.SetBool("falling", true);
        }
        
        if (face != 0) 
        {
             
            transform.localScale = new Vector3( face,1,1 );
        }

    }

    // ÇÐ»»¶¯»­
    void SwitchAnimation() 
    {
        
        if (anim.GetBool("jumping") && rb.velocity.y < 0)
        {
            
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);

        }
        else if (isHurt)
        {
            
                if (Mathf.Abs(rb.velocity.x) < 9.7f)
                {
                    anim.SetBool("hurting", false);

                    isHurt = false;
                }
            
            
        }
        else if (circle.IsTouchingLayers(floor))

        {
            anim.SetBool("falling", false);
            

        } else if (rb.velocity.y < -5)

        {
             
            anim.SetBool("falling", true);
            //capsule.enabled = false;
        } 
    }
    // ½Ó´¥¼ì²â
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Cherry")
        {
            
               
                
                Cherry cherry = collision.gameObject.GetComponent<Cherry>();
                cherry.Anim.SetBool("Blink", true);
     
        }
        if (collision.tag == "Gem")
        {

          
            
            Gem gem = collision.gameObject.GetComponent<Gem>();
            gem.Anim.SetBool("Blink", true);

        }
        
            

       

    }
    // Åö×²¼ì²â
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //½ÇÉ«ÊÜÉË
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (anim.GetBool("jumping") && collision.gameObject.tag == "Enemies")
        {

            hurtVoice.Play();
            anim.SetBool("jumping",false);
            anim.SetBool("Crouching",false);
            anim.SetBool("falling",false);
            anim.SetBool("hurting",true);
            if (enemy.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
            }
            isHurt = true;


        }
        else if (anim.GetBool("falling") && collision.gameObject.tag == "Enemies")
        {
           
            hurtVoice.Play();
            capsule.enabled = false;
            enemy.DeathAnimation();

                rb.velocity = new Vector2(rb.velocity.x, 12 );
                anim.SetBool("jumping", true);
            
        }
        else if (collision.gameObject.tag == "Enemies")

        {
            hurtVoice.Play();
            anim.SetBool("Crouching",false);
            anim.SetFloat("running",3);
            anim.SetBool("hurting",true);
            if (enemy.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(-10, rb.velocity.y);
            }
            isHurt = true;
            

        }
        //½ÇÉ«ËÀÍö
        

    }
    public void Run()
    {
        runVoice.Play();
    }

    //½ÇÉ«ÏÂ¶×
     void Crouch() 
    {


        //if (!Physics2D.OverlapCircle(pointCheck.position, 0.5f, floor))//
        {
            if (Input.GetButton("Crouch"))
                {
                    anim.SetFloat("running", 3);
                    anim.SetBool("Crouching", true);
                    capsule.enabled = false;
                }
                else
                {
                    anim.SetBool("Crouching", false);
                    capsule.enabled = true;
                }
         }
        
    }

    //½ÇÉ«ÌøÔ¾
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce );
        anim.SetBool("jumping", true);
        //capsule.enabled = false;
        jumpVoice.Play();
        isPressed = false;
    }

    void BloodControl() 
    {
        BLOOD--;
        if (BLOOD == 2)
        {
            Blood3.SetActive(false);
        }
        else if (BLOOD == 1)
        {
            Blood2.SetActive(false);
        } else if (BLOOD == 0) 
        {
            
            bgm.enabled = false;
            deadVoice.enabled = true;
            
            Blood1.SetActive(false);
            player.SetActive(false);
            gameOver.SetActive(true);
        }

    }

    public void cherryCount() 
    {
        goalVoice.Play();
        CherryGoal++;
    }
    public void gemCount() 
    {
        goalVoice.Play();
        GemGoal++;
    }

}
