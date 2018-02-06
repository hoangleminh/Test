using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsController : MonoBehaviour {
    public string appIDString = "ca-app-pub-8603558451003868~3299158362";
    public string AdmodBannerString = "ca-app-pub-8603558451003868/3521507887";
    public string AdmodTrunggianString = "ca-app-pub-8603558451003868/6127845147";

    BannerView bannerView;
    InterstitialAd trunggian;
    // Use this for initialization
    void Start () {
        MobileAds.Initialize(appIDString);
        ShowAdmodBanner();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowAdmodBanner()
    {
        if (this.bannerView == null)
        {
            this.bannerView = new BannerView(AdmodBannerString, AdSize.SmartBanner, AdPosition.Bottom);
        }
        else
            this.bannerView.Show();
    }

    public void DestroyAdmodBanner()
    {
        this.bannerView.Hide();
    }

    public void RequestTrunggian()
    {
        this.trunggian = new InterstitialAd(AdmodTrunggianString);
    }

    public void ShowTrunggian()
    {
        if(this.trunggian.IsLoaded())
        {
            this.trunggian.Show();
        }
    }

    public static AdsController _instance;
    public static AdsController instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }
}
