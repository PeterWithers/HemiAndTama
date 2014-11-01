using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {
	public Transform starPrefab;
	Rigidbody clone;

	// Use this for initialization
	void Start () {
		clone = Instantiate(starPrefab, transform.position, transform.rotation) as Rigidbody;
	}

	// Update is called once per frame
	void Update () {		
		//clone.transform.Rotate(Vector3.right * 10 * Time.deltaTime);
		//clone.transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
		//clone.gameObject.transform.Rotate(0, 1, 0);
		//clone.velocity = transform.TransformDirection(Vector3.forward * 10);
	}
}
