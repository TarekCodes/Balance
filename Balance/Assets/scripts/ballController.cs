using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{

    Rigidbody2D rigid;
    Animator ballAnimator;
    float speed = 5.0f;
    Vector2 maxVel = new Vector2(20.0f, 0.0f);
    bool isGrounded = true;
    Text scoreText;
    Text velocityText;
    AudioSource swishSound;
    AudioSource backboard;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ballAnimator = GetComponent<Animator>();
        swishSound = GetComponents<AudioSource>()[0];
        backboard = GetComponents<AudioSource>()[1];
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        velocityText = GameObject.FindGameObjectWithTag("speedText").GetComponent<Text>();
        scoreText.text = GameManager.instance.getLevelScore(SceneManager.GetActiveScene().name) + "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float userInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        if (((rigid.velocity.x < maxVel.x && userInput > 0) || (rigid.velocity.x > -maxVel.x && userInput < 0)) && isGrounded)
            rigid.velocity += new Vector2(speed * userInput, 0.0f);
        if (rigid.velocity.x > 4 || rigid.velocity.x < -4)
            ballAnimator.SetBool("moving", true);
        else
        {
            ballAnimator.SetBool("moving", false);
        }
        if (rigid.velocity.x > 5)
            speed = 25.0f;
        velocityText.text = ((int)(rigid.velocity.magnitude * 2.237))+ "";
        if (GameManager.instance.getLevelScore(SceneManager.GetActiveScene().name) == 4)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ramp")
            isGrounded = false;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform" || coll.gameObject.tag == "ramp")
            isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "scoreZone")
        {
            swishSound.Play();
            GameManager.instance.incrementLevelScore(SceneManager.GetActiveScene().name, 3);
            scoreText.text = GameManager.instance.getLevelScore(SceneManager.GetActiveScene().name) + "";
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "backboard")
            backboard.Play();

    }
}
