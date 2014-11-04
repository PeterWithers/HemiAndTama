using UnityEngine;
using System.Collections;

public class HamsterPlayer : MonoBehaviour {
	public float proximityLimit = -1.5f; // depth the player must be inside the wheel to act on it
	private int starCount = 0;
	private float tubeSpeedRms = 0;
	private CharacterController controller;
	private HamsterWheel hamsterWheel;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		hamsterWheel = GameObject.Find("HamsterWheel").GetComponentInChildren<HamsterWheel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		if (hit.gameObject.name == "star(Clone)") {
			starCount++;
			Destroy(hit.gameObject);
			//StarSpawn starSpawn = GetComponent<StarSpawn>();
			//starSpawn.spawnStar();
		}
		if (hit.gameObject.name == "tube container") {
			tubeSpeedRms = Mathf.Sqrt(tubeSpeedRms + controller.velocity.magnitude / 2);
		}
		if (hit.gameObject.name == "HamsterWheel") {		
			// todo: this distance calculation could be done with a simple comparison on the width axis
			var distance = Vector3.Distance (hit.transform.position, transform.position);
			//print("distance: " + distance);

			
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
				controller.Move(restMovement * Time.deltaTime);
			}
			//print("hit x: " + hit.transform.position.x);
			//print("hit y: " + hit.transform.position.y);
			//print("hit z: " + hit.transform.position.z);
			//print("player x: " + transform.position.x);
			//print("player y: " + transform.position.y);
			//print("player z: " + transform.position.z);

			//print("diff x: " + xDiff);
			//print("diff y: " + yDiff);
			//print("diff z: " + zDiff);
		}
	}
	void OnGUI() {
		GUI.Label(new Rect(150, 5, 120, 20), "stars: " + starCount);
		GUI.Label(new Rect(300, 5, 150, 20), "tubeSpeedRms: " + tubeSpeedRms);
		GUI.Label(new Rect(450, 5, 120, 20), "speed: " + controller.velocity.magnitude);
		GUI.Label (new Rect (10, 5, 100, 20), "wheel: " + (int)hamsterWheel.getMomentum());
	}
}
