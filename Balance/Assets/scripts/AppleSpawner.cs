using UnityEngine;
using System.Collections;

public class AppleSpawner : MonoBehaviour {

    public GameObject apple;   
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnApple", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnApple()
    {
        float x = Random.Range(-13f, 13f);
        float y = Random.Range(0f, 10f);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(apple, pos, Quaternion.identity);
    }
}
