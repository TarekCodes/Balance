using UnityEngine;
using System.Collections;

public class RockCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 0);
    }

    // Update is called once per frame
    void Update () {
        if (GetComponent<Rigidbody2D>().velocity.x < 15f)
            GetComponent<Rigidbody2D>().velocity = new Vector2(9f, 0);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "mountain" && !coll.gameObject.CompareTag("platform"))
            Destroy(coll.gameObject);

    }
}
