using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{

    bool paused = false;
    GameObject pauseMenu;
    Text levelNo;
    GameObject enemy;
    GameObject player;
    int levelIndex;
    private float tempVolume;


    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        resumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            showMenu();
        }
        else
            if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            resumeGame();
        }
    }


    void showMenu()
    {
        GameManager.instance.playMenuSelect();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    void resumeGame()
    {
        if(paused)
            GameManager.instance.playMenuSelect();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }


    IEnumerator nextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene((levelIndex + 1) % 5);
    }

    IEnumerator restartLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelIndex);
    }

    public void restartLevel()
    {
        GameManager.instance.playMenuSelect();
        GameManager.instance.setLevelScore(SceneManager.GetActiveScene().name, 0);  //reset level score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("menuScene");
    }

    public void quitGame()
    {
        GameManager.instance.playMenuSelect();
        Application.Quit();
    }

    public void muteVolume(bool check)
    {
        if (check)
        {
            tempVolume = GameManager.instance.getVolume();
            GameManager.instance.changeVolume(0);
        }
        else
            GameManager.instance.changeVolume(tempVolume);
    }
}
