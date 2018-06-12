using UnityEngine;
using System.Collections;

public class MyFollowCursor : MonoBehaviour {
	public float offset = 0.05f;
	private Vector3 dir;
	private Vector3 posOffset;
	private float limit;
	private Transform player;		// Reference to the player's transform.
	private Rigidbody2D playerRB;

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("eyes").transform;
		playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		Vector3 movement = playerRB.velocity;
		movement.Normalize();
		dir = Vector3.ClampMagnitude(movement, offset);
		Vector3 newPos = player.position + dir;
		transform.position = newPos;
	}
}
