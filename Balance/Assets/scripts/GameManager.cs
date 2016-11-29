using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	AudioSource[] audioSources;
	AudioSource background;
	AudioSource menuSelect;
    private int overallScore = 0;


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

    public void incrementScore()
    {
        overallScore++;
    }

    public void incrementScore(int n)
    {
        overallScore+=n;
    }

    public void decrementScore()
    {
        overallScore--;
    }


}
