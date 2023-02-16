using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crank : MonoBehaviour
{
    private Animator Anim;
    private AudioSource crankVoice;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        crankVoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Players")
        {
            Anim.enabled = true;
            crankVoice.enabled = true;
        }

    }
}
