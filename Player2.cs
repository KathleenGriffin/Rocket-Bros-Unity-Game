using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	private float MOVEMENT_MULTIPLIER = 1f;
	public Vector3 PullVector = new Vector3(0f, 0f, 0f);

	private Rigidbody body;
    private float MAX_VELOCITY = 8f;
	public float BoostLeft;
	public bool IsDead = false;

	public GameObject FuelTank;

	void Start() {
		body = GetComponent<Rigidbody>();
		Physics.gravity = new Vector3(0, -5.0F, 0);
    }

	void Update() {

		FuelTank.transform.localScale = new Vector3 (0.26f, BoostLeft/150f * 0.5f, 0.07f);

        if (Input.GetKeyDown(KeyCode.RightAlt)) {
            //BUTTON 1
        }
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            //BUTTON 2
        }
    }

    void FixedUpdate () {
		float dy = Input.GetAxis ("Vertical");
		float dx = Input.GetAxis ("Horizontal") / 6;

        //transform.position += new Vector3 (dx * MOVEMENT_MULTIPLIER, dy * MOVEMENT_MULTIPLIER, 0f);

        if(BoostLeft > 0f) {
            body.AddForce(new Vector3(0f, 20f * dy, 0f), ForceMode.Force);
            BoostLeft -= Mathf.Min(BoostLeft, dy);

            if (body.velocity.y > MAX_VELOCITY) {
                body.velocity = new Vector3(body.velocity.x, MAX_VELOCITY, body.velocity.z);
			}
			transform.Rotate (new Vector3(0f, dy * 15, 0f), Space.World);
			//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Max(Mathf.Min(-45, (45*dx) - transform.rotation.z), 45));
        }

        /*if (Input.GetKey(KeyCode.LeftShift)) {
			if (MOVEMENT_MULTIPLIER == 0.5f)
				MOVEMENT_MULTIPLIER = 1f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			MOVEMENT_MULTIPLIER = 0.5f;
		}*/

        transform.position += new Vector3(dx * MOVEMENT_MULTIPLIER, 0f, 0f);
		if (transform.position.x < -6.15f) {
			transform.position = new Vector3(-6.15f, transform.position.y, transform.position.z);
		} else if (transform.position.x > 6.15f) {
			transform.position = new Vector3(6.15f, transform.position.y, transform.position.z);
		}
	}

}