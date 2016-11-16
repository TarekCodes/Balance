using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level3_Restarter : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene("level3");
		}
	}
}
