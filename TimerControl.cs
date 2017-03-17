using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{


    [SerializeField]
    private Text timeText;
    private bool paused = false;
    private float timeLimit;
    public Transform PauseScreen;
    public Transform GameOverScreen;
    private float highScore = 0;
    private int score = 0;
    public Text gameOverText;
	public GameObject P1;
	public GameObject P2;
	private bool gameIsOver = false;

	void Start(){
		Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update(){

		if (P1.GetComponent<Player> ().IsDead == true || P2.GetComponent<Player2>().IsDead == true) {
			gameOver ();
		}

        if (Input.GetKeyDown(KeyCode.Escape)) { Pause(); }

        if (!paused)
        {
            doTime();
        }

		score = (int)timeLimit*3;

		if (gameIsOver == true) {
			if (Input.anyKey) {
				SceneManager.LoadScene(1);
			}
		}



    }

    void doTime()
    {
        //seconds += Time.deltaTime;
        //var timeSpan = System.TimeSpan.FromSeconds(seconds);
        //timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        timeLimit += Time.deltaTime;
        timeText.text = timeLimit.ToString("F2");

    }


    public void Pause()
    {
        if (PauseScreen.gameObject.activeInHierarchy == false)
        {
            PauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }



    //I assume game over will be controlled in here too since the final idea is to have a time limit
    //also it's easier for me to keep all the code I did in one place :P

    public void gameOver()
    {
		gameIsOver = true;
        GameOverScreen.gameObject.SetActive(true);

        if (score > highScore) {
            highScore = score;
            gameOverText.text = "NEW HIGH SCORE:" + highScore;
        } else {
            gameOverText.text = "HIGH SCORE:" + highScore + "\nYOUR SCORE:" + score;
        }
        Time.timeScale = 0;
    }





}
