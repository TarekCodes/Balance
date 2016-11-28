﻿using UnityEngine;
using System.Collections;

public class RockCollider : MonoBehaviour {

    float initSpeed = 15f;
    float speed = 7f;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(initSpeed, 0);
    }

    // Update is called once per frame
    void Update () {
        if (GetComponent<Rigidbody2D>().velocity.x < initSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "mountain" && !coll.gameObject.CompareTag("platform"))
            Destroy(coll.gameObject);

    }
}
