using UnityEngine;
using System.Collections;

public class ObjectInBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -8.5)
            Destroy(this.gameObject);
	}
}
