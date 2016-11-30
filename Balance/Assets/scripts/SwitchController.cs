using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("gate");
            Destroy(obj);//.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);
        }
    }
}
