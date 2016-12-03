using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class coinHandler : MonoBehaviour {

    AudioSource coinSound;
	// Use this for initialization
	void Start () {
        coinSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            coinSound.Play();
            string currentLevelName = SceneManager.GetActiveScene().name;
            switch (currentLevelName)
            {
                case "level1":
                    GameManager.instance.incrementLevelScore(currentLevelName, 1);
                    break;
                case "level2":
                    GameManager.instance.incrementLevelScore(currentLevelName, 1);
                    break;
                case "level3":
                    GameManager.instance.incrementLevelScore(currentLevelName, 1);
                    break;
                case "level4":
                    GameManager.instance.incrementLevelScore(currentLevelName, 1);
                    break;
                case "level5":
                    GameManager.instance.incrementLevelScore(currentLevelName, 5);
                    break;
                case "level6":
                    GameManager.instance.incrementLevelScore(currentLevelName, 1);
                    break;
            }
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject,1);
        }
    }
}
