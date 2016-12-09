using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    GameObject infoWindow;
    GameObject endWindow;
    bool paused = false;
    GameObject pauseMenu;
    Text levelNo;
    GameObject enemy;
    GameObject player;
    private float tempVolume;


    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
        infoWindow = GameObject.FindGameObjectWithTag("infowindow");
        endWindow = GameObject.Find("LevelCompletePopup");
        resumeGame();
    }

    void Update()
    {
        endWindow = GameObject.Find("LevelCompletePopup");
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !paused && (endWindow == null || !endWindow.activeSelf) && !infoWindow.activeSelf)
        {
            
            showMenu();
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && paused && (endWindow == null || !endWindow.activeSelf) && !infoWindow.activeSelf)
            {
                resumeGame();
            }
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
        if (paused)
        {
            GameManager.instance.playMenuSelect();
            Time.timeScale = 1;
        }
        pauseMenu.SetActive(false);    
        paused = false;
    }

    public void restartLevel()
    {
        GameManager.instance.playMenuSelect();
        GameManager.instance.setLevelScore(SceneManager.GetActiveScene().name, 0);  //reset level score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMenu()
    {
        GameManager.instance.calcTotalScore();
        GameManager.instance.saveScore();
        Time.timeScale = 1;
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("menuScene");
    }

    public void quitGame()
    {
        GameManager.instance.playMenuSelect();
        SceneManager.LoadScene("savingScene");
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
