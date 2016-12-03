using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonsController : MonoBehaviour {


	void Start() {
			
	}

	public void clickButton() {
		GameManager.instance.playMenuSelect();
	}

	public void startNewGame()
	{
        GameManager.instance.resetLevelScores();
		clickButton ();
		SceneManager.LoadScene("chooseLevel");
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
        SceneManager.LoadScene("savingScene");
	}

    public void mainMenuHighscores()
    {
        clickButton();
        SceneManager.LoadScene("highscoresScene");
    }
}
