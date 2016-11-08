using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonsController : MonoBehaviour {

	public void startNewGame()
    {
        SceneManager.LoadScene("testScene");
    }
}
