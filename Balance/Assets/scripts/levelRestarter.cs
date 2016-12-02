using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelRestarter : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			restart ();
		}
    }

	public void restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
