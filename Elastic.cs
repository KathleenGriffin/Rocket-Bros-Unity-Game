using UnityEngine;
using System.Collections;

public class Elastic : MonoBehaviour {

    public GameObject p1;
	public GameObject p2;
	public GameObject CenterSphere;

    private float RESTED_ELASTIC_LENGTH = 4f;
    private float PULL_MULTIPLIER = 8f;

	void FixedUpdate () {
		float stretchedDistance = (Vector3.Distance (p1.transform.position, p2.transform.position) - RESTED_ELASTIC_LENGTH) / 2;

		if (Vector3.Distance (p1.transform.position, p2.transform.position) > RESTED_ELASTIC_LENGTH) {

			Vector3 directionToP2 = p2.transform.position - p1.transform.position;
			Vector3 directionToP1 = p1.transform.position - p2.transform.position;

			p1.GetComponent<Rigidbody> ().AddForce (directionToP2 * stretchedDistance, ForceMode.Force);
			p2.GetComponent<Rigidbody> ().AddForce (directionToP1 * stretchedDistance, ForceMode.Force);
			
		}

		CenterSphere.transform.position = (p1.transform.position + p2.transform.position)/2;
    }


}
