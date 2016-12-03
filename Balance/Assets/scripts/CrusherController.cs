using UnityEngine;
using System.Collections;

public class CrusherController : MonoBehaviour {
    Rigidbody2D rigid;
    public float speed = 8f;
    public float up;
    public float down;
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
        if (transform.position.y > up)
        {
            rigid.velocity = new Vector2(0, -speed);
        }
        if (transform.position.y < down)
        {
            rigid.velocity = new Vector2(0, speed);
        }
    }
}
