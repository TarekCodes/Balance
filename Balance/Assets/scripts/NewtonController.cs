using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewtonController : MonoBehaviour {

    Rigidbody2D rigid;
    float speed = 8.0f;
    bool left = false;
    Text scoreText;
    AudioSource jab;
    GameObject completePopup;

	// Use this for initialization
	void Start () {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        jab = GetComponent<AudioSource>();
        completePopup = GameObject.Find("LevelCompletePopup");
        completePopup.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.instance.getLevelScore("level4") > 20){
            Time.timeScale = 0;
            completePopup.SetActive(true);
        }
	}

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(movement * speed , 0);
        if (movement != 0)
            GetComponent<Animator>().SetBool("running", true);
        else
            GetComponent<Animator>().SetBool("running", false);
        if (movement < 0 && !left)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            left = true;
        }
        else if(movement > 0 && left){
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                left = false;
            }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "apple")
        {
            jab.Play();
            Destroy(other.gameObject);
            GameManager.instance.incrementLevelScore("level4", 1);
            scoreText.text = GameManager.instance.getLevelScore("level4") + "";
        }
    }

}
