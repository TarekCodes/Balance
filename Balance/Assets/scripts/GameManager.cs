using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public AudioSource[] audioSources;
	AudioSource background;
	AudioSource menuSelect;
    public int overallScore = 0;
    public int level1Score = 0;
    public int level2Score = 0;
    public int level3Score = 0;
    public int level4Score = 0;
    public int level5Score = 0;
    public int level6Score = 0;
    private bool stopSaving = false;
    private static int MAX_SCORES = 10;
    public string scoreKey = "HighScore";
    public string nameKey = "HighScoreName";
    public string playerName;
    public GameObject enterYourName;


    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSources = GetComponents<AudioSource>();
            background = audioSources[0];
            menuSelect = audioSources[1];
            background.loop = true;
            playbackgroundMusic();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

	void Start () {
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

    public GameManager getInstance()
    {
        return instance;
    }

    //increment overall score
    public void incrementScore()
    {
        overallScore++;
    }

    //add n to overall score
    public void incrementScore(int n)
    {
        overallScore+=n;
    }

    //decrement overall score
    public void decrementScore()
    {
        overallScore--;
    }

    //use to increment individual level score
    public void incrementLevelScore(string level, int n)
    {
        switch (level)
        {
            case "level1":
                level1Score+=n;
                break;
            case "level2":
                level2Score += n;
                break;
            case "level3":
                level3Score += n;
                break;
            case "level4":
                level4Score += n;
                break;
            case "level5":
                level5Score += n;
                break;
            case "level6":
                level6Score += n;
                break;
        }
    }

    //use to decrement individual level score
    public void decrementLevelScore(string level, int n)
    {
        switch (level)
        {
            case "level1":
                level1Score -= n;
                break;
            case "level2":
                level2Score -= n;
                break;
            case "level3":
                level3Score -= n;
                break;
            case "level4":
                level4Score -= n;
                break;
            case "level5":
                level5Score -= n;
                break;
            case "level6":
                level6Score -= n;
                break;
        }
    }

    //returns individual level scores
    public int getLevelScore(string level)
    {
        switch (level)
        {
            case "level1":
                return level1Score;
            case "level2":
                return level2Score;
            case "level3":
                return level3Score;
            case "level4":
                return level4Score;
            case "level5":
                return level5Score;
            case "level6":
                return level6Score;
        }
        return 0;
    }

    //set individual level scores
    public void setLevelScore(string level, int n)
    {
        switch (level)
        {
            case "level1":
                level1Score = n;
                break;
            case "level2":
                level2Score = n;
                break;
            case "level3":
                level3Score = n;
                break;
            case "level4":
                level4Score = n;
                break;
            case "level5":
                level5Score = n;
                break;
            case "level6":
                level6Score = n;
                break;
        }
    }

    public void changeVolume(float value)
    {
        foreach (AudioSource audioS in instance.audioSources)
            audioS.volume = value;
    }

    public float getVolume()
    {
        return audioSources[0].volume;
    }


    public void setName()
    {
        instance.playMenuSelect();
        Text nameField = GameObject.FindGameObjectWithTag("nameField").GetComponent<Text>();
        if(nameField.text == "")
        {
            Object obj = Instantiate(enterYourName,  GameObject.FindGameObjectWithTag("initCanvas").GetComponent<Transform>(),false);
            Destroy(obj, 2);
        }
        else
        {
            playerName = nameField.text;
            SceneManager.LoadScene("menuScene");
        }

    }


    public void saveScore()
    {
        int pScore = overallScore;
        string pName = playerName;

        for (int i = 0; i < MAX_SCORES; i++)
        {
            string curNameKey = (nameKey + i).ToString();
            string curScoreKey = (scoreKey + i).ToString();

            if (!(PlayerPrefs.HasKey(curScoreKey)))
            {
                if (stopSaving)
                    break;
                PlayerPrefs.SetInt(curScoreKey, pScore);
                PlayerPrefs.SetString(curNameKey, pName);
                stopSaving = true;
            }
            else
            {
                int score = PlayerPrefs.GetInt(curScoreKey);


                if (pScore > score)
                {
                    int tempScore = score;
                    string tempName = PlayerPrefs.GetString(curNameKey);

                    PlayerPrefs.SetInt(curScoreKey, pScore);
                    PlayerPrefs.SetString(curNameKey, pName);

                    pName = tempName;
                    pScore = tempScore;
                    stopSaving = false;
                }
            }
        }
        //for (int i = 0; i < MAX_SCORES; i++)
        //{
        //    print(PlayerPrefs.GetString("HighScoreName" + i) + " " + PlayerPrefs.GetInt("HighScore" + i));
        //}
    }

    public void restartLevel()
    {
        instance.setLevelScore(SceneManager.GetActiveScene().name, 0);  //reset level score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
