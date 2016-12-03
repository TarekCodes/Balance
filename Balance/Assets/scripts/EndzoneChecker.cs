using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class EndzoneChecker : MonoBehaviour {

	float timer;
	bool inZone;
	bool timerActive;
	Text timerText;
	bool scoreUp;
	GameManager gameManager;
	GameObject completePopup;

	// Use this for initialization
	void Start () {
		scoreUp = false;
		timerText = GameObject.FindGameObjectWithTag ("timerText").GetComponent<Text> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		completePopup = GameObject.Find ("LevelCompletePopup");
		completePopup.SetActive (false);
		inZone = false;
		timerActive = false;
	}

	// Update is called once per frame
	void Update () {
		if (timerActive && Time.time - timer >= 3.0f) {
			//temporarily changes to menuScene
			LevelComplete ();
		} else if (!inZone)
			timerActive = false;

		if (timerActive)
			UpdateTimer ();
		else
			timerText.text = "0.00";
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("endzone")) {
			if (!timerActive) {
				timer = Time.time;
				timerActive = true;
			}
			inZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("endzone")) {
			inZone = false;
		}
	}

	void LevelComplete() {
		gameManager.setLevelScore ("level2", 5);
		if (!scoreUp) {
			scoreUp = true;
		}
		completePopup.SetActive (true);
		Time.timeScale = 0;
	}

	void UpdateTimer() {
		float time = Time.time - timer;
		timerText.text = "" + time.ToString("F2");
	}
}
