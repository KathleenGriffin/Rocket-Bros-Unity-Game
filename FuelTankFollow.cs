using UnityEngine;
using System.Collections;

public class FuelTankFollow : MonoBehaviour {

	public GameObject P1;
	public GameObject P1Tank;

	public GameObject P2;
	public GameObject P2Tank;



	private Vector3 P1Offset;
	private Vector3 P2Offset;

	void Start () {
		P1Offset = new Vector3(-0.5f, 0.2f, 0f);
		P2Offset = new Vector3(0.5f, 0.2f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		P1Tank.transform.position = P1.transform.position + P1Offset;
		P2Tank.transform.position = P2.transform.position + P2Offset;
	}
}
