using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using GoogleMobileAds.Api;
using System;

public class Menu : MonoBehaviour
{
    public AudioSource Voice;
    public GameObject PausePanel;
    public AudioSource bgm;
    public AudioMixer audioMixer;
    public GameObject gameOver;
    //创建激励广告对象
    private RewardedAd rewardedAd;

    [System.Obsolete]
    public void CreateAndLoadRewardedAd()
    {
#if     UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif   UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        //this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        //this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        //this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

    }

    [Obsolete]
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    [Obsolete]
    private void Start()
    {
        //初始化
        MobileAds.Initialize(initStatus => { });
        CreateAndLoadRewardedAd();
    }

   /* public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for "+ amount.ToString() + " " + type);
    }*/

    [Obsolete]
    public void StartGame() 
    {
        Voice.Play();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        gameOver.SetActive(true);
        Invoke("LoadGame",2f);
    }
    void LoadGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() 
    {
        Voice.Play();
        Invoke("Quit_Game",0.8f);
        
    }
    void Quit_Game()
    {
        Application.Quit();
    }
    public void QuitGameQuickly()
    {
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
