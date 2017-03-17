using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

    void OnTriggerStay(Collider c) {
		if (c.gameObject.CompareTag ("Player")) {
			c.gameObject.GetComponent<Player>().BoostLeft = Mathf.Min(c.gameObject.GetComponent<Player>().BoostLeft + 1f, 150f);
		} else {
			if (c.gameObject.CompareTag ("Player2")) {
                c.gameObject.GetComponent<Player2>().BoostLeft = Mathf.Min(c.gameObject.GetComponent<Player2>().BoostLeft + 1f, 150f);
			} else {
				return;
			}
		}
    }

}