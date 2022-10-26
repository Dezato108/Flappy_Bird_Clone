using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    private Bird bird;

    public Text scoreText, scoreBoardText, highScoreBoardText;

    [SerializeField] GameObject getReady, scoreBoardPanel, silverMedal, goldMedal;

    private int score;

    void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
        PlayerPrefs.SetInt("Score", 0);

    }
    // Start is called before the first frame update
    void Start()
    {
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.hasTheGameStarted)
        {
            getReady.SetActive(false);
        }

        if (bird.hasBirdDied)
        {
            scoreBoardPanel.SetActive(true);
        }

        ScoreUpdate();

        SetTheMedal();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    void ScoreUpdate()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score.ToString();

        scoreBoardText.text = score.ToString();

        highScoreBoardText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        SetNewHighScore();
    }

    void SetNewHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void SetTheMedal()
    {
        if (score>=5 && score<10)
        {
            silverMedal.SetActive(true);
        }
        else if (score>=10)
        {
            goldMedal.SetActive(true);
        }
        else
        {
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
        }
        
    }
}
