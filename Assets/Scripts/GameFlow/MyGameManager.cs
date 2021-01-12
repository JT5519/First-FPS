using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//game manager, handles the game state
public class MyGameManager : MonoBehaviour
{
    //static game manager so only one copy of it exists
    public static MyGameManager gm;

    public bool gameOver = false;
    public AudioSource gameAudio;
    //UI elements
    public Text scoreText;
    private int score;
    public Text timerText;
    public float time = 15f;
    public Image borderofScore;

    public bool canBeatLevel = false;
    public int beatLevelScore = 10;
    //UI
    public GameObject playAgainButtons;
    public GameObject nextLevelButtons;

    public string PlayAgainSceneName;
    public string NextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        if(!gm)
        {
            gm = GetComponent<MyGameManager>();
        }
        //setting initial values
        scoreText.text = score.ToString("0");
        timerText.text = time.ToString("0.00");
        borderofScore.enabled = false;
        playAgainButtons.SetActive(false);
        nextLevelButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            if(time<=0)
            {
                EndGame();
            }
            else if(canBeatLevel==true && score>=beatLevelScore)
            {
                BeatLevel();
            }
            else
            {
                time -= Time.deltaTime;
                if(time<0)
                {
                    time = 0f;
                }
                timerText.text = time.ToString("0.00");
            }
        }
    }
    void EndGame() //function to end game
    {
        timerText.text = "GAME OVER";
        gameOver = true;
        borderofScore.enabled = true;
        gameAudio.pitch = 0.5f;
        playAgainButtons.SetActive(true);
    }
    void BeatLevel() //function to beat level
    {
        timerText.text = "LEVEL COMPLETE";
        gameOver = true;
        borderofScore.enabled = true;
        gameAudio.pitch = 0.7f;
        nextLevelButtons.SetActive(true);
    }
    public void ScoreAdd(int scoreAdd,float timeAdd) //scroe accumulation function
    {
        score += scoreAdd;
        scoreText.text = score.ToString("0");
        time += timeAdd;
        if(time<0f)
        {
            time = 0f;
        }
    }
    public void PlayAgainGame() 
    {
        SceneManager.LoadScene(PlayAgainSceneName);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(NextSceneName);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("_MainMenu");
    }
    public void playerDead()
    {
        gameOver = true;
        EndGame();
    }
}
