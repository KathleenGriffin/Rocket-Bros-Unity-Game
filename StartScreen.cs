using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	public GameObject Ring;

	void Update () {
	
        if (Input.anyKey) {
            SceneManager.LoadScene(1);
        }

		Ring.transform.Rotate (new Vector3(0f, -1f, 0f));

	}
}
