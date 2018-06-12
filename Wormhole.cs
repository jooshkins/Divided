using UnityEngine;

public class Wormhole : MonoBehaviour {

	public Vector3 target;

	void OnTriggerEnter2D(Collider2D other) {
	
		other.transform.position = target;
	
	}
}
