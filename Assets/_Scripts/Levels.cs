using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public Button[] levelButtons; // Levels sahnesindeki butonlarý buraya ekleyin.
    public GameObject[] lockImages; // Butonlarýn kilit görsellerini buraya ekleyin.
    public Button backButton;

    void Start()
    {
        // Ýlk levelin kilidini aç
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 1); // Level 1 her zaman açýk.
        }

        // Butonlarýn durumunu güncelle
        UpdateLevelButtons();
    }

    public void LevelButton()
    {
        SceneManager.LoadScene("Levels");
    }

    void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            string levelKey = "Level" + (i + 1); // Level1, Level2, vb.
            bool isUnlocked = PlayerPrefs.GetInt(levelKey, 0) == 1;

            // Eðer kilitliyse, butonun Text bileþenini kapat ve kilit görselini göster
            if (levelButtons[i] != null)
            {
                levelButtons[i].interactable = isUnlocked;

                // Buton üzerindeki Text'i devre dýþý býrak
                Text buttonText = levelButtons[i].GetComponentInChildren<Text>();
                if (buttonText != null)
                {
                    buttonText.enabled = isUnlocked; // Kilitli deðilse Text'i göster
                }
            }

            // Kilit görselini yönet
            if (lockImages[i] != null)
            {
                lockImages[i].SetActive(!isUnlocked); // Kilitliyse göster, kilitli deðilse gizle
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        string levelKey = "Level" + levelIndex;
        if (PlayerPrefs.GetInt(levelKey, 0) == 1)
        {
            SceneManager.LoadScene("Level " + levelIndex);
        }
    }

    public void UnlockNextLevel(int currentLevel)
    {
        string nextLevelKey = "Level" + (currentLevel + 1);
        PlayerPrefs.SetInt(nextLevelKey, 1); // Bir sonraki levelin kilidini aç
        PlayerPrefs.Save(); // Deðiþiklikleri kaydet
    } 

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
