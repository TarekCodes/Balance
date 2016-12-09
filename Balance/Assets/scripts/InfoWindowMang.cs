using UnityEngine;
using System.Collections;

public class InfoWindowMang : MonoBehaviour {

    public bool active = true;
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
        active = false;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("infowindow").SetActive(false);
    }
}
