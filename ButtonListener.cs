using UnityEngine;
using System.Collections;

public class ButtonListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			//P1Button
		} 
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//P2Button
		}

		if (Input.GetKey (KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha2)) {
			//Return to main screen or quit app
		}
	}
}
