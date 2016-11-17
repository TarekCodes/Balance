using UnityEngine;
using System.Collections;

public class NewtonController : MonoBehaviour {

    Rigidbody2D rigid;
    float speed = 7.0f;
    bool left = false;
    int score = 0;
	// Use this for initialization
	void Start () {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
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
            Destroy(other.gameObject);
            score++;
            print(score);
        }
    }

}
