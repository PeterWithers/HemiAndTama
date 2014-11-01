using UnityEngine;
using System.Collections;

public class HamsterPlayer : MonoBehaviour {
	public float proximityLimit = -1.5f; // depth the player must be inside the wheel to act on it

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.name == "HamsterWheel") {		
			// todo: this distance calculation could be done with a simple comparison on the width axis
			var distance = Vector3.Distance (hit.transform.position, transform.position);
			print("distance: " + distance);

			
			float xDiff = hit.transform.position.x - transform.position.x;
			float yDiff = hit.transform.position.y - transform.position.y;
			float zDiff = hit.transform.position.z - transform.position.z;

			if(distance<3 && xDiff > proximityLimit){				
				// todo: the -zDiff should be addative to the wheel movement and this should also reflect the force back on the player so that it can oscilate if the player suddenly stops pushing
				// set the wheel in motion
				float wheelSpeed = hit.gameObject.GetComponentInChildren<HamsterWheel>().setSpeed(-zDiff);
				// move the player in relation to the force they have put on the wheel
				//Vector3 restPosition = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z);
				Vector3 restMovement = new Vector3(0, 0, zDiff * 0.5f);
				CharacterController controller = GetComponent<CharacterController>();
				controller.Move(restMovement * Time.deltaTime);
			}
			//print("hit x: " + hit.transform.position.x);
			//print("hit y: " + hit.transform.position.y);
			//print("hit z: " + hit.transform.position.z);
			//print("player x: " + transform.position.x);
			//print("player y: " + transform.position.y);
			//print("player z: " + transform.position.z);

			print("diff x: " + xDiff);
			print("diff y: " + yDiff);
			print("diff z: " + zDiff);
		}
	}
}
