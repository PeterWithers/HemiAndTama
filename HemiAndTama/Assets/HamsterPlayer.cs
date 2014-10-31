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
			hit.gameObject.GetComponentInChildren<HamsterWheel>().setSpeed(-1);
		}
	}
}
