using UnityEngine;
using System.Collections;

public class HamsterPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.name == "HamsterWheel") {			
			var distance = Vector3.Distance (hit.transform.position, transform.position);
			print("distance: " + distance);

			
			float xDiff = hit.transform.position.x - transform.position.x;
			float yDiff = hit.transform.position.y - transform.position.y;
			float zDiff = hit.transform.position.z - transform.position.z;

			if(distance<3){				
				// todo: the -zDiff should be addative to the wheel movement and this should also reflect the force back on the player so that it can oscilate if the player suddenly stops pushing
				// set the wheel in motion
				hit.gameObject.GetComponentInChildren<HamsterWheel>().setSpeed(-zDiff);
				// move the player in relation to the force they have put on the wheel
				Vector3 playerPosition = transform.position;
				playerPosition.z += zDiff / 2;
				//transform.position = playerPosition;
				transform.position = Vector3.Lerp(transform.position, playerPosition, 0.1f);
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
