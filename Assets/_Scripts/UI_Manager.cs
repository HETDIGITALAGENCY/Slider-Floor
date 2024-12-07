using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    GoogleAdsManager googleads;

    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _levelsButton;

    private void Start()
    {
        googleads = FindObjectOfType<GoogleAdsManager>();
        Time.timeScale = 0.0f;
        _menuPanel.SetActive(true);
        _playButton.onClick.AddListener(PlayButton);
        _quitButton.onClick.AddListener(QuitButton);
    }

    private void PlayButton()
    {
        int highestLevel = GetHighestUnlockedLevel();
        SceneManager.LoadScene("Level " + highestLevel);
        Time.timeScale = 1.0f;
    }

    private void QuitButton()
    {
        Application.Quit();
    }

    // En y�ksek a��lm�� olan level'� bul
    private int GetHighestUnlockedLevel()
    {
        int highestLevel = 1; // Default olarak Level 1'i ba�lat�yoruz.
        // Maksimum level say�s�n� buraya g�re ayarlayabilirsin
        int maxLevel = 10;

        for (int i = 1; i <= maxLevel; i++)
        {
            string levelKey = "Level" + i;
            if (PlayerPrefs.GetInt(levelKey, 0) == 1) // Level a��lm��sa
            {
                highestLevel = i; // Bu level a��ld�ysa, highestLevel'� g�ncelle
            }
        }

        return highestLevel; // En y�ksek a��lm�� seviyeyi d�nd�r
    }
}
