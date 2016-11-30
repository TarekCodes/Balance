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

    //Gamemanger methods are commented out for now because you gotta run each level from the menu scene if you want them to work.

    void showMenu()
    {
        //GameManager.instance.playMenuSelect();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    void resumeGame()
    {
        //GameManager.instance.playMenuSelect();
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
        //GameManager.instance.playMenuSelect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMenu()
    {
        //GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("menuScene");
    }

    public void quitGame()
    {
        //GameManager.instance.playMenuSelect();
        Application.Quit();
    }
}
