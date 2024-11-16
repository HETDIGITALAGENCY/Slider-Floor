using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class FinishFloor : MonoBehaviour
{
    GoogleAdsManager googleads;
    

    private void Start()
    {
        googleads = FindObjectOfType<GoogleAdsManager>(); 


            
    }  
    
    private void OnCollisionEnter(Collision col)
    { 
        if (col.gameObject.CompareTag("Player"))
        { 
            googleads.LoadInterstitialAd();
            googleads.ShowInterstitialAd();
        } 

            RequestConfiguration requestConfiguration = new RequestConfiguration();
            requestConfiguration.TestDeviceIds.Add("6ee96d1b15e3d4fccad468606de360e8");
            MobileAds.SetRequestConfiguration(requestConfiguration);

    }

   
}
