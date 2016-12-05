using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

    string curName = GameManager.instance.nameKey;
    string curScore = GameManager.instance.scoreKey;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < GameManager.MAX_SCORES; i++)
        {
            if (PlayerPrefs.HasKey((curScore + i)))
            {
                GameObject.FindGameObjectWithTag("highscores").GetComponent<Text>().text += PlayerPrefs.GetString(curName + i) + "\t\t\t\t\t\t\t" + PlayerPrefs.GetInt(curScore + i) + "\n";
            }
            else
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
