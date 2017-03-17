using UnityEngine;
using System.Collections;

public class Vert_Scrolling_Camera : MonoBehaviour {

	public GameObject PlatformPrefab;
	public float ScrollSpeed;

	public GameObject Player1;
	public GameObject Player2;

	public float Timeout;
	public float TimeCount = 0f;
	public float TotalTime = 0f;

	public float DifficultyMultiplier = 1f;

	private float xRange = 10f;
	private float yOffset = 10f;

	private float distanceToUnderCamera = 11.3f;
	private float p1DeadTimer = 0f;
	private float p2DeadTimer = 0f;

	void FixedUpdate () {
		TimeCount += Time.deltaTime;
		TotalTime += Time.deltaTime;
		DifficultyMultiplier += 0.0002f;
		transform.position += new Vector3 (0f, ScrollSpeed * DifficultyMultiplier, 0f);//Move camera up

		if (TimeCount > Timeout) {
			if (Random.Range (0, 20) == 10) {
				Object platform = Instantiate (PlatformPrefab, new Vector3 (transform.position.x - (xRange / 2) + Random.Range (0f, xRange), transform.position.y + yOffset, 0f), new Quaternion (0f, 0f, 0f, 0f));
                Object.Destroy(platform, 20);
                TimeCount = 0f;
			}
		}

		if (Player1.transform.position.y < transform.position.y - distanceToUnderCamera) {
			p1DeadTimer += Time.deltaTime;
			if (p1DeadTimer > 2f) {
				Player1.GetComponent<Player> ().IsDead = true;
			}
		}

		if (Player2.transform.position.y < transform.position.y - distanceToUnderCamera) {
			p2DeadTimer += Time.deltaTime;
			if (p2DeadTimer > 2f) {
				Player2.GetComponent<Player2> ().IsDead = true;
			}
		}
	}

	void Update(){
		Vector3 midPoint = (Player1.transform.position / 2) + (Player2.transform.position / 2);
		if (midPoint.y > transform.position.y - 2f) {
			float diff = midPoint.y - (transform.position.y - 2f);
			transform.position += new Vector3 (0f, diff, 0f);
		}
	}

}