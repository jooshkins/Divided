using UnityEngine;

public class SlowPlayerOnContact : MonoBehaviour {

	public float AddDragToPlayer;
	void OnTriggerEnter2D (Collider2D other) {
		other.GetComponent<Rigidbody2D>().drag = other.GetComponent<Rigidbody2D>().drag + AddDragToPlayer;
	}
	void OnTriggerExit2D (Collider2D other) {
		other.GetComponent<Rigidbody2D>().drag = other.GetComponent<Rigidbody2D>().drag - AddDragToPlayer;
	}
}
