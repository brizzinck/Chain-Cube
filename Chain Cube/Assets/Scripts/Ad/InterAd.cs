using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    const string INTERSTITIAL_ID = "ca-app-pub-3940256099942544/1033173712";
    private InterstitialAd _interstitialAd;
    private AdRequest _adRequest;
    public void ShowAd()
    {
        if (_interstitialAd.IsLoaded())
        {
            _interstitialAd.Show();
            _interstitialAd.LoadAd(_adRequest);
        }
    }
    private void Start()
    {
        RequestInterstitial();
    }
    private void RequestInterstitial()
    {
        _interstitialAd = new InterstitialAd(INTERSTITIAL_ID);
        _adRequest = new AdRequest.Builder().Build();
        _interstitialAd.LoadAd(_adRequest);
    }
}
