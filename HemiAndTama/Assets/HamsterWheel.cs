using UnityEngine;
using System.Collections;

public class HamsterWheel : MonoBehaviour {
	float maxSpeed = 100f;
	float momentum = 50f;
	float decay = 0.5f;

	public void setSpeed(float speed) {
		// speed is a value from -1 to 1 where 0 is stationary
		print ("speed: " + speed);
		momentum = maxSpeed * speed;
	}

	void Update() {
		momentum = (momentum > 0)? momentum - decay : momentum + decay;
		transform.Rotate(Vector3.back, Time.deltaTime * momentum);
	}

	void FixedUpdate() {
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "momentum: " + momentum);
	}
}
