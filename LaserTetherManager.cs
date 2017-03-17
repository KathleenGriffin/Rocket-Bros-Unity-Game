using UnityEngine;
using System.Collections;

public class LaserTetherManager : MonoBehaviour {

	public GameObject Point1;
	public GameObject Point2;
	private LineRenderer lr;

	void Start () {
		this.lr = GetComponent<LineRenderer> ();
	}

	void Update () {
		lr.SetPosition (0, Point1.transform.position);
		lr.SetPosition (1, Point2.transform.position);
		float distance = Vector3.Distance (Point1.transform.position, Point2.transform.position);
		lr.SetWidth (0.15f / distance, 0.15f / distance);
	}
}
