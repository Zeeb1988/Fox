using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Menu : MonoBehaviour
{
    public AudioSource Voice;
    public GameObject PausePanel;
    public AudioSource bgm;
    public AudioMixer audioMixer;
    public void StartGame() 
    {
        Voice.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame() 
    {
        Voice.Play();
        Application.Quit();
    }
    public void ReStart() 
    {
        Voice.Play();
        SceneManager.LoadScene("Main01");
    }
    public void PauseButton() 
    {
        bgm.enabled = false;
        Voice.Play();
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseButton()
    {
        bgm.enabled = true;
        Voice.Play();
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    
    }

    public void SetVoice(float value) 
    {
        audioMixer.SetFloat("MainVoice",value);
    }

}
