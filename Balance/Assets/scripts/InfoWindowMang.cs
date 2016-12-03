using UnityEngine;
using System.Collections;

public class InfoWindowMang : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
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
