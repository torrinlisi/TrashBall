using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    int score = 0;
    public Text scoreText;
    public GameObject gameStartUI;

    public Text endScoreText;
    public GameObject gameEndUI;
    public bool onEndScreen = false;

    private void Awake()
    {
        instance = this;
        scoreText.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameStart()
    {
        gameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void ShowEndScreen()
    {
        BallController.instance.StopBounce();
        gameEndUI.SetActive(true);
        scoreText.gameObject.SetActive(false);

        string holdEndScoreText;
        if(score > 4)
        {
            holdEndScoreText = score.ToString();
        } else
        {
            holdEndScoreText = "TRASH";
        }

        endScoreText.text = holdEndScoreText;
        onEndScreen = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        score = 0;
        scoreText.text = score.ToString();
    }

    public void ScoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
