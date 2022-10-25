using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    private Bird bird;

    [SerializeField] GameObject getReady, scoreBoardPanel;

    void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
