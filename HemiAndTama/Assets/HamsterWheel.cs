using UnityEngine;
using System.Collections;

public class HamsterWheel : MonoBehaviour {
	float maxSpeed = 100f;
	float momentum = 50f;
	float decay = 0.1f;

	public void setSpeed(float speed) {
		// speed is a value from -1 to 1 where 0 is stationary
		momentum = maxSpeed * speed;
	}

	void Update() {
		momentum = (momentum > 0)? momentum - decay : 0;
		Debug.Log ("momentum: " + momentum);
		transform.Rotate(Vector3.back, Time.deltaTime * momentum);
	}

	void FixedUpdate() {
	}
}
