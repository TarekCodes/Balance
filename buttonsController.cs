using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonsController : MonoBehaviour {

	public GameObject soundHandler;

	void Start() {
			
		soundHandler = GameObject.FindGameObjectWithTag ("soundHandler");
	}

	public void clickButton() {
		soundHandler.GetComponent<SoundPlayer> ().playMenuSelect();
	}

	public void startNewGame()
	{
		clickButton ();
		SceneManager.LoadScene("testScene");
    }

	public void mainMenuOptions() {
		clickButton ();
	}

	public void mainMenuAbout() {
		clickButton ();
	}

	public void mainMenuQuit() {
		clickButton ();
	}
}
