using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    Slider soundSlider;
    InputField nameField;
    public GameObject enterYourName;
    // Use this for initialization
    void Start () {
        soundSlider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        soundSlider.value = GameManager.instance.getVolume();
        nameField = GameObject.FindGameObjectWithTag("nameField").GetComponent<InputField>();
        nameField.text = GameManager.instance.playerName;

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
        if (nameField.text == "")
        {
            Object obj = Instantiate(enterYourName, GameObject.FindGameObjectWithTag("initCanvas").GetComponent<Transform>(), false);
            Destroy(obj, 2);
        }
        else
        {
            GameManager.instance.playerName = nameField.text;
            SceneManager.LoadScene("menuScene");
        }
    }
}
