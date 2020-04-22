using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdMobInterstitial : MonoBehaviour
{
    private string AppID = "ca-app-pub-3940256099942544~3347511713";  //тестовые
    private string InterstitialAdUnitID = "ca-app-pub-3940256099942544/1033173712"; //тестовые

    private InterstitialAd interstitialAd;

    void Start()
    {
        MobileAds.Initialize(AppID);

        interstitialAd = new InterstitialAd(InterstitialAdUnitID);
        interstitialAd.LoadAd(new AdRequest.Builder().Build());

        interstitialAd.OnAdClosed += HandlerOnClosed;
    }

    public void HandlerOnClosed(object sendler, EventArgs args)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowAds()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
