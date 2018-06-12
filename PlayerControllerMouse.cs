using UnityEngine;

public class PlayerControllerMouse : MonoBehaviour {
	public float speed;
	public Boundary mouseboundary;

	void Start () {
		Cursor.visible = false;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Mouse X");
		float moveVertical = Input.GetAxis("Mouse Y");

	// I will need to change to a vector 3 if using 3d effects
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical);

		GetComponent<Rigidbody2D>().AddForce (movement * speed);

		GetComponent<Rigidbody2D>().position = new Vector2 
		(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, mouseboundary.xMin, mouseboundary.xMax),
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, mouseboundary.yMin, mouseboundary.yMax)
		);
	}
}
