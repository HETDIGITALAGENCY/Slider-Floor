using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdsManager : MonoBehaviour
{
    public string AndroidId = "ca-app-pub-9584256452772726~5605740031";

#if UNITY_ANDROID
    string bannerId = "ca-app-pub-9584256452772726/2045768978";
    string interId = "ca-app-pub-9584256452772726/8576454084"; 

#elif UNITY_IPHONE
    string bannerId = "ca-app-pub-9584256452772726/6802409239";
    string interId = "ca-app-pub-9584256452772726/4028934482"; 

#endif

    BannerView bannerView;
    InterstitialAd interstitialAd;

    private void Start()
    {
        

        // Mobil reklamları başlatma
        MobileAds.Initialize(initStatus => 
        {
            print("Reklam Başlatıldı.");
        });
        
         // Reklam cihazı ayarlarını yapma
        RequestConfiguration requestConfiguration = new RequestConfiguration();
        requestConfiguration.TestDeviceIds.Add("6ee96d1b15e3d4fccad468606de360e8");
        MobileAds.SetRequestConfiguration(requestConfiguration);

        
        // Banner reklamını yükle
        CreateBannerView();
        LoadBannerAd();

        // Interstitial reklamını yükle
        LoadInterstitialAd();
    }

    void Update()
    {
       
    }

    #region Banner

    public void LoadBannerAd()
    {
        if (bannerView == null)
        {
            CreateBannerView();
        }

        // Banner reklam isteği
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");
        print("Banner reklamı yükleniyor.");
        bannerView.LoadAd(adRequest);
    }

    public void CreateBannerView()
    {
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }

    #endregion

    #region Interstitial

    public void LoadInterstitialAd()
    {
        // Eski reklamı yok et
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        // Reklam yükleme isteği
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // Reklamı yükle
        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                return;
            }

            // Reklam yüklendiğinde
            print("Geçiş Reklamı Yüklendi: " + ad.GetResponseInfo());
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
            print("Reklam hazır değil.");
        }
    }

    #endregion
}
