using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cherry : MonoBehaviour
{
    public Animator Anim;

    
    
    
     void Start()
    {
        
        Anim = GetComponent<Animator>();
        
    }
    
    // Start is called before the first frame update
    public void Death()
    {
        
        Destroy(gameObject);
        

    }
    void GoalVoice() { FindObjectOfType<Player>().cherryCount(); }



}
