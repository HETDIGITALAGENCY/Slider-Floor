using UnityEngine;
using GoogleMobileAds.Api;


public class GoogleAdsManager : MonoBehaviour
{
    public string AndroidId = "ca-app-pub-9584256452772726~5605740031";


     #if UNITY_ANDROID
     string bannerId = "ca-app-pub-9584256452772726/2045768978" ; 
     string interId = "ca-app-pub-9584256452772726/8576454084" ;

     #elif UNITY_IPHONE
     string bannerId = "ca-app-pub-9584256452772726/6802409239" ; 
     string interId = "ca-app-pub-9584256452772726/4028934482" ; 

     #endif 

    BannerView bannerView;
    InterstitialAd interstitialAd;


    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => {

            print("Reklam basladi");
        
        });

         CreateBannerWiew(); 
         LoadBannerAd();
    }

    #region Banner
    public void LoadBannerAd()
    {
        CreateBannerWiew();

        if (bannerView == null)
        {
            CreateBannerWiew();
        } 

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        print("Loading banner ad");
        bannerView.LoadAd(adRequest); // show the banner on the screen
    } 

    public void CreateBannerWiew()
    {
 
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }
    #endregion
    #region
    
    public void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print("Gecis Reklami Yuklenemedi" + error);
                return;
            }

            print("Gecis reklami yuklendi" + ad.GetResponseInfo());
            interstitialAd = ad;
        });
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            print("reklam hazir degil");
        }
    } 


    #endregion

}
