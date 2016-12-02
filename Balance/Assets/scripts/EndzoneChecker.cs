﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class EndzoneChecker : MonoBehaviour {

	float timer;
	bool inZone;
	bool timerActive;
	Text timerText;

	// Use this for initialization
	void Start () {
		inZone = false;
		timerActive = false;
		timerText = GameObject.FindGameObjectWithTag ("timerText").GetComponent<Text> ();
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
		SceneManager.LoadScene ("level3");
	}

	void UpdateTimer() {
		float time = Time.time - timer;
		timerText.text = "" + time.ToString("F2");
	}
}
