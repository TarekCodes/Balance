using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlatformerCharacter2D>().m_MaxSpeed += 2;
            Destroy(gameObject);
        }

    }
}
