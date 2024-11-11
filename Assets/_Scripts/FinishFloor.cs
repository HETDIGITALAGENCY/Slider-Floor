using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

   
}
