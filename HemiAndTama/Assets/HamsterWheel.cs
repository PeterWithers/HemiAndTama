using UnityEngine;
using System.Collections;

public class HamsterWheel : MonoBehaviour {
	float maxSpeed = 100f;
	float momentum = 50f;
	float decay = 0.5f;

	public float setSpeed(float speed) {
		// speed is a value from -1 to 1 where 0 is stationary
		//print ("speed: " + speed);
		momentum = maxSpeed * speed;
		return momentum / maxSpeed;
	}

	public float getMomentum() {
		return momentum;
	}

	void Update() {
		momentum = (momentum > 0)? momentum - decay : momentum + decay;
		transform.Rotate(Vector3.back, Time.deltaTime * momentum);
	}

	void FixedUpdate() {
	}

	//void OnGUI() {
	//	GUI.Label (new Rect (5, 5, 150, 20), "momentum: " + (int)momentum);
	//}
}
