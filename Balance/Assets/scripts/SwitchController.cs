using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playMenuSelect();
            GameObject obj = GameObject.FindGameObjectWithTag("gate");
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -7f);
            obj.GetComponent<BoxCollider2D>().enabled = false;
            print("hi");
            //Destroy(obj);//
        }
    }
}
