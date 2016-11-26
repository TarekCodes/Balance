using UnityEngine;
using System.Collections;

public class CrusherController : MonoBehaviour {
    Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, -7f);
        print(transform.position.y);
	}

    void Update()
    {
    }

        // Update is called once per frame
        void FixedUpdate () {
        if (transform.position.y < 6)
        {
            print(transform.position.y);
            rigid.velocity = new Vector2(0, 7f);
        }
        else if (transform.position.y > 12)
        {
            print(transform.position.y);
            rigid.velocity = new Vector2(0, -7f);
        }
	}
}
