using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public Button[] levelButtons; // Levels sahnesindeki butonlar� buraya ekleyin.
    public GameObject[] lockImages; // Butonlar�n kilit g�rsellerini buraya ekleyin.
    public Button backButton;

    void Start()
    {
        // �lk levelin kilidini a�
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 1); // Level 1 her zaman a��k.
        }

        // Butonlar�n durumunu g�ncelle
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

            // E�er kilitliyse, butonun Text bile�enini kapat ve kilit g�rselini g�ster
            if (levelButtons[i] != null)
            {
                levelButtons[i].interactable = isUnlocked;

                // Buton �zerindeki Text'i devre d��� b�rak
                Text buttonText = levelButtons[i].GetComponentInChildren<Text>();
                if (buttonText != null)
                {
                    buttonText.enabled = isUnlocked; // Kilitli de�ilse Text'i g�ster
                }
            }

            // Kilit g�rselini y�net
            if (lockImages[i] != null)
            {
                lockImages[i].SetActive(!isUnlocked); // Kilitliyse g�ster, kilitli de�ilse gizle
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
        PlayerPrefs.SetInt(nextLevelKey, 1); // Bir sonraki levelin kilidini a�
        PlayerPrefs.Save(); // De�i�iklikleri kaydet
    } 

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
