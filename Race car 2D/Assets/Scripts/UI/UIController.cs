using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text ScoreText, YourScoreText, HighScoreText;
    private const string HighScore = "High Score";

    public void SetScore(int score)
    {
        ScoreText.text = "" + score;
    }

    public static UIController _instance;
    public static UIController instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    public StartPanel startpanel;
    public EndPanel endpanel;
    public GamePanel gamepanel;
    public IntroductionButton intructionpanel;
    public Button PauseButton;

    // Use this for initialization
    void Start () {
        //Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowStartPanel()
    {
        Time.timeScale = 0;
        startpanel.gameObject.SetActive(true);
        gamepanel.gameObject.SetActive(false);
        endpanel.gameObject.SetActive(false);
        intructionpanel.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(false);
    }

    public void ShowGamePanel()
    {
        startpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(true);
        endpanel.gameObject.SetActive(false);
        intructionpanel.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
    }

    public void ShowEndPanel(int score)
    {
        startpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(false);
        endpanel.gameObject.SetActive(true);
        intructionpanel.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(false);
        YourScoreText.text = "" + score;
        if(score > GetHighScore())
        {
            SetHighScore(score);
        }
        HighScoreText.text = "" + GetHighScore().ToString();
    }

    public void ShowIntructionPanel()
    {
        startpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(false);
        endpanel.gameObject.SetActive(false);
        intructionpanel.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
    }

    public void ShowGameplay()
    {
        intructionpanel.gameObject.SetActive(false);
        startpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(false);
        endpanel.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        MusicController.instance.PlayGameMusic();
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScore, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);
    }
}
