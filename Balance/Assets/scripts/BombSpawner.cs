using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {
    public GameObject bomb;
    private Vector3[] spawnPos;
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBomb", 0, 2);
        spawnPos = new Vector3[5];
    }

    // Update is called once per frame
    void Update () {
	
	}

    void spawnBomb()
    {
        float y = 7f;
        spawnPos[0] = new Vector3(23, y);
        spawnPos[1] = new Vector3(44, y);
        spawnPos[2] = new Vector3(59, y);
        spawnPos[3] = new Vector3(93, y);
        spawnPos[4] = new Vector3(110, y);
        for (int i = 0; i < spawnPos.Length; i++)
        {
            Instantiate(bomb, spawnPos[i], Quaternion.identity);
        }
    }
}
