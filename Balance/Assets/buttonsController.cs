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
		SceneManager.LoadScene("gameScene");
    }

	public void mainMenuOptions() {
		clickButton ();
        SceneManager.LoadScene("optionsScene");
    }

    public void mainMenuAbout() {
		clickButton ();
        SceneManager.LoadScene("aboutScene");
    }

    public void mainMenuQuit() {
		clickButton ();
        Application.Quit();
	}
}
