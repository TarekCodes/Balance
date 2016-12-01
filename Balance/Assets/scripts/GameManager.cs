using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public AudioSource[] audioSources;
	AudioSource background;
	AudioSource menuSelect;
    private int overallScore = 0;
    private int level1Score = 0;


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
        }
    }

    //returns individual level scores
    public int getLevelScore(string level)
    {
        switch (level)
        {
            case "level1":
                return level1Score;
        }
        return 0;
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
}
