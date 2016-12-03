using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Display : MonoBehaviour {

	GameManager gameManager;
	Text playerText;
	Text scoreText;
	Text totalText;

	void Start() {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		playerText = GameObject.Find ("PlayerName").GetComponent<Text> ();
		scoreText = GameObject.Find ("LevelScore").GetComponent<Text> ();
		totalText = GameObject.Find ("TotalScore").GetComponent<Text> ();
	}

	void Continue() {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex == 11)
            SceneManager.LoadScene("menuScene");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	void Update() {
		playerText.text = gameManager.playerName;
		if(SceneManager.GetActiveScene().buildIndex == 6) {
			scoreText.text = gameManager.level1Score.ToString();
		}
		else if(SceneManager.GetActiveScene().buildIndex == 7) {
			scoreText.text = gameManager.level2Score.ToString();
		}
		else if(SceneManager.GetActiveScene().buildIndex == 8) {
			scoreText.text = gameManager.level3Score.ToString();
		}
		else if(SceneManager.GetActiveScene().buildIndex == 9) {
			scoreText.text = gameManager.level4Score.ToString();
		}
		else if(SceneManager.GetActiveScene().buildIndex == 10) {
			scoreText.text = gameManager.level5Score.ToString();
		}
		else if(SceneManager.GetActiveScene().buildIndex == 11) {
			scoreText.text = gameManager.level6Score.ToString();
		}
        GameManager.instance.calcTotalScore();
		totalText.text = gameManager.overallScore.ToString();
	}
}
