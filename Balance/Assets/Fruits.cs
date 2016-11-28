using UnityEngine;
using System.Collections;

public class Fruits : MonoBehaviour {


	public GameObject fruit_0;
	public GameObject fruit_1;
	public GameObject fruit_2;
	public GameObject fruit_3;
	public GameObject fruit_4;
	public GameObject fruit_5;
	public GameObject fruit_6;

	float x;
	float y;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnFruit0", 1f, 3f);
		InvokeRepeating("spawnFruit1", 2f, 5f);
		InvokeRepeating("spawnFruit2", 3f, 3.3f);
		InvokeRepeating("spawnFruit3", 3.5f, 5f);
		InvokeRepeating("spawnFruit4", 2f, 3f);
		InvokeRepeating("spawnFruit5", 3f, 3.5f);
		InvokeRepeating("spawnFruit5", 1f, 3.5f);

	}

	// Update is called once per frame
	void Update () {
	}

	void spawnFruit0()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_0, pos, Quaternion.identity);

	}

	void spawnFruit1()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_1, pos, Quaternion.identity);
	}

	void spawnFruit2()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_2, pos, Quaternion.identity);
	}

	void spawnFruit3()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_3, pos, Quaternion.identity);
	}

	void spawnFruit4()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_4, pos, Quaternion.identity);
	}

	void spawnFruit5()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_5, pos, Quaternion.identity);
	}

	void spawnFruit6()
	{
		x = Random.Range (460f, 520f);
		y = Random.Range (250f, 260f);
		pos = new Vector3 (x, y, 0);
		Instantiate (fruit_6, pos, Quaternion.identity);
	}
}
