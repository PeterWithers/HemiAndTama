using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {
	public Transform starPrefab;

	void Start () {
		spawnStar ();
	}

	public void spawnStar() {
		Rigidbody clone = Instantiate(starPrefab, transform.position, transform.rotation) as Rigidbody;
		//var respawn = GameObject.FindWithTag ("StarSpawn");
		//Instantiate (starPrefab, respawn.transform.position, respawn.transform.rotation);
	}
}
