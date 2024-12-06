using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class FinishFloor : MonoBehaviour
{
    GoogleAdsManager googleads;
    public int currentLevel;
    Levels levels;



    private void Start()
    {
        currentLevel = int.Parse(SceneManager.GetActiveScene().name.Split(' ')[1]);
        googleads = FindObjectOfType<GoogleAdsManager>();
        levels = FindObjectOfType<Levels>();
    }  
    
    private void OnCollisionEnter(Collision col)
    { 
        if (col.gameObject.CompareTag("Player"))
        {
            levels.UnlockNextLevel(currentLevel);
           // googleads.LoadInterstitialAd();
            googleads.ShowInterstitialAd();
        } 

            RequestConfiguration requestConfiguration = new RequestConfiguration();
            requestConfiguration.TestDeviceIds.Add("6ee96d1b15e3d4fccad468606de360e8");
            MobileAds.SetRequestConfiguration(requestConfiguration);

    }

   
}
