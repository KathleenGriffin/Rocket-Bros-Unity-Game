using UnityEngine;
using System.Collections;

public class PlayerOne : MonoBehaviour {

    public Vector3 PullVector;
    private float initialPosZ;
    
	void Start () {
        initialPosZ = transform.position.z;
	}
	
	void FixedUpdate () {
		
        float dy = Input.GetAxis("Vertical") * 5;
        float dx = Input.GetAxis("Horizontal") * 5;

        Vector3 movementVector = new Vector3(PullVector.x + dx, PullVector.y + dy, PullVector.z);

        transform.position += new Vector3(Mathf.Lerp(0, movementVector.x, Time.deltaTime),
            Mathf.Lerp(0, movementVector.y, Time.deltaTime),
            Mathf.Lerp(0, movementVector.z, Time.deltaTime));

        this.transform.position = new Vector3(transform.position.x, transform.position.y, initialPosZ);
    }
}
