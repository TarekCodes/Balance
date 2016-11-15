using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelRestarter : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
