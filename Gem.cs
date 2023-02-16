using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gem : MonoBehaviour
{
    public Animator Anim;

    

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void Death()
    {
        
        Destroy(gameObject);


    }

    void GoalVOice() { FindObjectOfType<Player>().gemCount(); }
}
