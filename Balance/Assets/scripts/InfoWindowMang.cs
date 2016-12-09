using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InfoWindowMang : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameManager.instance.getRepeat(SceneManager.GetActiveScene().name)%5!=0)
            GameObject.FindGameObjectWithTag("infowindow").SetActive(false);
        else 
            Time.timeScale = 0;
        GameManager.instance.addRepeat(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void startGame()
    {
        GameManager.instance.playMenuSelect();
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("infowindow").SetActive(false);
    }
}
