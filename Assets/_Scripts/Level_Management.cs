using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Level_Management : MonoBehaviour
{
    GoogleAdsManager googleads;
    PlayerController playerController;
    public GameObject _continuePanel;
    public Button _continueButton;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _pauseButton; 
     public GameObject MenuPanel; 


    public void Start()
    {
        googleads = FindObjectOfType<GoogleAdsManager>();
        Time.timeScale = 1.0f;
        _continuePanel.SetActive(false);
        _pausePanel.SetActive(false);

        playerController = FindObjectOfType<PlayerController>();

        _continueButton.onClick.AddListener(ContinueButton);
        _resumeButton.onClick.AddListener(ResumeButton);
        _pauseButton.onClick.AddListener(PauseButton);
        _text.text = SceneManager.GetActiveScene().name;
    }

    public void ContinueButton()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseButton()
    {   
        MenuPanel.SetActive(true);
        Time.timeScale = 0.0f;
        _pausePanel.SetActive(true);


        
    }

    public void ResumeButton()
    {  
        MenuPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _continuePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
