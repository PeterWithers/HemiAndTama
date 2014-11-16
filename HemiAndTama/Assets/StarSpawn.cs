using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {
	public GameObject[] starSpawnPoints;
	public GameObject starPrefab;
	void Start () {
		//starSpawnPoints = GameObject.FindObjectsOfType<StarSpawnPoint> ();
		//starSpawnPoints = GameObject.FindObjectsOfType<StarSpawnPoint>();
		//starSpawnPoints = GetComponentsInChildren<StarSpawnPoint>();
		//starPrefab = GameObject.FindObjectOfType<Star> ();
		spawnStar ();
	}

	public void spawnStar() {
		for (int pointIndex = 0; pointIndex < starSpawnPoints.Length; pointIndex++){
			Rigidbody clone = Instantiate(starPrefab, starSpawnPoints[pointIndex].transform.position, starSpawnPoints[pointIndex].transform.rotation) as Rigidbody;
		}
		//var respawn = GameObject.FindWithTag ("StarSpawn");
		//Instantiate (starPrefab, respawn.transform.position, respawn.transform.rotation);
	}
}
