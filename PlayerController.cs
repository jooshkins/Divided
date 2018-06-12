using UnityEngine;
using System.Collections;

// Putting boundary in a class allows it to be used else where
[System.Serializable]
public class Boundary
{
    public float xMin = -100;
    public float xMax = 100;
    public float yMin = -100;
    public float yMax = 100;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

	// I will need to change to a vector 3 if using 3d effects
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D>().AddForce (movement * speed);
		GetComponent<Rigidbody2D>().position = new Vector2 
		(
			Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
		);
	}
}
