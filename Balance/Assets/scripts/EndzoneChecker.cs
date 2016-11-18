using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndzoneChecker : MonoBehaviour {

	float timer;
	bool inZone;
	bool triggered;

	// Use this for initialization
	void Start () {
		inZone = false;
		triggered = false;
	}

	// Update is called once per frame
	void Update () {
		if (inZone && Time.time - timer >= 3.0f) {
			//temporarily changes to menuScene
			SceneManager.LoadScene("level3");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("endzone") && !inZone) {
			if (!triggered) {
				timer = Time.time;
				triggered = true;
			}
			inZone = true;
		}
	}
}
