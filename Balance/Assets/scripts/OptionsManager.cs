using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    Slider soundSlider;
	// Use this for initialization
	void Start () {
        soundSlider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        soundSlider.value = GameManager.instance.audioSources[0].volume;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sliderChange()
    {
        GameManager.instance.changeVolume(soundSlider.value);
    }

    public void backToMenu()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("menuScene");
    }
}
