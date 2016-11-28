using UnityEngine;
using System.Collections;

public class CrusherController : MonoBehaviour {
    Rigidbody2D rigid;
    float speed = 8f;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0,speed);
	}

    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (transform.position.y > 9)
        {
            rigid.velocity = new Vector2(0, -speed);
        }
        if (transform.position.y < 3.7f)
        {
            rigid.velocity = new Vector2(0, speed);
        }
    }
}
