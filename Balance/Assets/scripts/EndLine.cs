using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour {

    GameObject completePopup;
    // Use this for initialization
    void Start () {
        completePopup = GameObject.Find("LevelCompletePopup");
        completePopup.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.incrementLevelScore(SceneManager.GetActiveScene().name, 5);
            completePopup.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
