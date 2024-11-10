/*using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GecisReklami : MonoBehaviour
{
    public static GecisReklami instance;

#if UNITY_ANDROID
    string _adUnitID = "ca-app-pub-9584256452772726/8576454084";
#elif UNITY_IPHONE
    string _adUnitID = "ca-app-pub-9584256452772726/4028934482";
#else
    string _adUnitID = "ca-app-pub-2563028499947801/6286448346";pa
#endif

    InterstitialAd _GecisReklami;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    { 
        DontDestroyOnLoad(this.gameObject);
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });
        GecisReklamiOlustur();
    }

    public void GecisReklamiOlustur()
    {
        if (_GecisReklami != null)
        {
            _GecisReklami.Destroy();
            _GecisReklami = null;
        }

        var adRequest = new AdRequest();

        InterstitialAd.Load(_adUnitID, adRequest,
            (InterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {

                    Debug.LogError("Reklam yüklenirken hata oluþtu HATA : " + error);
                    return;
                }

                _GecisReklami = Ad;

            });

        ReklamOlaylariniDinle(_GecisReklami);
    }


    void ReklamOlaylariniDinle(InterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Ödüllü Reklam {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Geçiþ reklamý bir gösterim kaydetti.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Geçiþ reklamý týklandý.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Geçiþ reklamý tam ekran açýldý.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Geçiþ reklamý kapatýldý.");
            GecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Geçiþ reklamý açýlamadý. HATA : " + error);
            GecisReklamiOlustur();
        };
    }

    public void GecisReklamiGoster()
    {

        if (_GecisReklami != null && _GecisReklami.CanShowAd())
        {
            _GecisReklami.Show();
            Debug.Log("reklam gösterildi");
        }
        else
        {
            Debug.Log("Geçiþ reklamý henüz hazýr deðil");
        }

    }

    void ReklamiOldur()
    {
        _GecisReklami.Destroy();
    }

}
*/
