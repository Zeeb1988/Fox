using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

interface IDeadScene
{
    void SwitchDeadScene();
}
public class deadLine : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource deadVoice;
    public GameObject player;
    public GameObject gameOver;
    public GameObject blood;
    public GameObject poseButton;
    public GameObject jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Players")
        {
            blood.SetActive(false);
            bgm.enabled = false;
            deadVoice.enabled = true;
            player.SetActive(false);
            Invoke(nameof(Restart), 2f);
            poseButton.SetActive(false);
            jumpButton.SetActive(false);
        }
    }

    void Restart()
    {
        gameOver.SetActive(true);
    }



    
}
