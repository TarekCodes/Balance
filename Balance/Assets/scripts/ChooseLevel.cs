using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToLevel1()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level1");
    }

    public void goToLevel2()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level2");
    }

    public void goToLevel3()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level3");
    }

    public void goToLevel4()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level4");
    }

    public void goToLevel5()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level5");
    }

    public void goToLevel6()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("level6");
    }
}
