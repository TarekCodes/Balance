using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Display : MonoBehaviour {

	void Continue() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
