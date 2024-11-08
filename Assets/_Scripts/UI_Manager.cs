using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
   

    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        Time.timeScale = 0.0f;
        _menuPanel.SetActive(true);
        _playButton.onClick.AddListener(PlayButton);
        _quitButton.onClick.AddListener(QuitButton);
       
    }
    private void PlayButton()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
    }
    private void QuitButton()
    {
        Application.Quit();
    }
    
    
    
}