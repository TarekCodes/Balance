using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	AudioSource[] audioSources;
	AudioSource background;
	AudioSource menuSelect;
	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad(this);
		audioSources = GetComponents<AudioSource> ();
		background = audioSources [0];
		menuSelect = audioSources [1];
		playbackgroundMusic ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playbackgroundMusic() {
		background.Play ();
	}

	public void playMenuSelect() {
		menuSelect.Play ();
	}
}
