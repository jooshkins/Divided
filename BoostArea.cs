using UnityEngine;

public class BoostArea : MonoBehaviour {

	public float speed;
	public Vector2 targetPosition;

	void OnTriggerStay2D (Collider2D other) {
		other.GetComponent<Rigidbody2D>().AddForce(targetPosition * speed);
	}
}

