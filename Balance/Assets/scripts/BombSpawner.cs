using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {
    public GameObject bomb;
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBomb", 0, 1);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void spawnBomb()
    {
        float y = 7f, x;
        for (int i = 0; i < 3; i++)
        {
            x = Random.Range(1, 133f);
            Vector3 pos = new Vector3(x, y, 0);
            Instantiate(bomb, pos, Quaternion.identity);
        }
    }
}
