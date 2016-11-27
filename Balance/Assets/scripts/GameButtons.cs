using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour {

	public GameObject[] DisplayWhenPaused;
	public GameObject[] DisplayWhenResumed;

	// Use this for initialization
	void Start () {

		//if (pauseText == null) {
		DisplayWhenPaused = GameObject.FindGameObjectsWithTag("WhenPaused");
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		//if (pauseText == null) {
		DisplayWhenResumed = GameObject.FindGameObjectsWithTag("WhenResumed");
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);

		//pauseText.SetActive(false);

	}

	// Update is called once per frame
	void Update () {

	}

	public void PauseGame()
	{
		Time.timeScale = 0.0f;
		//pauseText.SetActive (true);
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (true);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (false);



	}

	public void ResumeGame()
	{
		Time.timeScale = 1.0f;
		//pauseText.SetActive (false); 
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);


	}

	public void Menu()
	{
		SceneManager.LoadScene ("menu");
	}
}
