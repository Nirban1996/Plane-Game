using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject missile;

	public Transform[] SpawnPoints;

	public int numberOfMissiles, highestMissiles = 4;

    public GameObject GameOverPanel, MainPanel;
    public Text scoreText, GameOverScoreText;

    public int score;

	private float timer, delayTime= 5;

	public bool gameOver;

	private static GameManager instance;

	public static GameManager Instance
	{
		get{ 
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
		timer = delayTime;
        ActivateMainPanel(true);
        ActivateGameOverPanel(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameOver) {
			SpawnMissile ();
			
            scoreText.text = "Score: " + score;
            GameOverScoreText.text = "Score: " + score;
        }
        ShowGameOver();
    }


	void SpawnMissile()
	{
		timer -= Time.deltaTime;

		if (timer <= 0 && numberOfMissiles <= highestMissiles) {
			timer = delayTime;
			numberOfMissiles++;
			int indx = Random.Range (0, SpawnPoints.Length);

			Instantiate (missile, SpawnPoints [indx].position, SpawnPoints [indx].rotation);
		}
	}

	private bool gameOverShown = false;

	void ShowGameOver()
	{
		if (gameOver && !gameOverShown) {
			Debug.Log ("Game Over");
			gameOverShown = true;
            // Invoke("ShowGameOverPanel", 2);
            // Invoke("HideMainPanel", 2);

            ActivateMainPanel(false);
            ActivateGameOverPanel(true);


        }
	}

    public void ActivateMainPanel(bool flag)
    {
        MainPanel.SetActive(flag);
    }

    public void HideMainPanel()
    {
        ActivateMainPanel(false);
    }

    public void ShowGameOverPanel()
    {
        ActivateGameOverPanel(true);
    }

    public void ActivateGameOverPanel(bool flag)
    {
        GameOverPanel.SetActive(flag);
    }

    public void IncrementScore()
    {
        score++;
    }
}
