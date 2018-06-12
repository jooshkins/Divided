using UnityEngine;

public class Mover : MonoBehaviour {
	public float speed;
	public Vector2 targetPosition;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = targetPosition * speed;
	}
}
