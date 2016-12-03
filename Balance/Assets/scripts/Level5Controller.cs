using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level5Controller : MonoBehaviour {
    GameObject wall1;
    GameObject wall2;
    GameObject wall3;
    Text scoreText;
	// Use this for initialization
	void Start () {
        wall1 = GameObject.FindGameObjectWithTag("wall1");
        wall2 = GameObject.FindGameObjectWithTag("wall2");
        wall3 = GameObject.FindGameObjectWithTag("wall3");
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        if (GameManager.instance.getLevelScore("level5") < 5)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
        }
        else
        {
            if (GameManager.instance.getLevelScore("level5") < 10)
            {
                wall2.SetActive(false);
                wall3.SetActive(false);
            }
            else
            {
                if (GameManager.instance.getLevelScore("level5") < 15)
                    wall3.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "SCORE: " + GameManager.instance.getLevelScore("level5");
        if (GameManager.instance.getLevelScore("level5") >= 20)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
