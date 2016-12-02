using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
