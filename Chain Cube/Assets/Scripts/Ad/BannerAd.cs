using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    const string BANNER_ID = "ca-app-pub-3940256099942544/6300978111";
    private BannerView _bannerView;
    private void Start()
    {
        RequestBanner();
    }
    private void RequestBanner()
    {
        _bannerView = new BannerView(BANNER_ID, AdSize.Banner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
        _bannerView.LoadAd(adRequest);
    }
}
