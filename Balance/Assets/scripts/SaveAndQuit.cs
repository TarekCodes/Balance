using UnityEngine;
using System.Collections;

public class SaveAndQuit : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameManager.instance.calcTotalScore();
        GameManager.instance.saveScore();
        StartCoroutine(quitAfter(2f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator quitAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}
