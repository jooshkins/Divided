using UnityEngine;

public class MoverSine : MonoBehaviour {
	public float MoveSpeed = 5.0f;                 
	public float frequency = 20.0f; // Speed of sine movement
	public float magnitude = 0.5f; // Size of sine movement
	public bool MoveRight;
	public bool MoveLeft;
	public bool MoveUp;
	public bool MoveDown;
	public bool VertAxis;
	public bool HorizAxis;
	private Vector3 axis;
	private Vector3 pos;

	void Start () {
		pos = transform.position;

		if (VertAxis) {
			axis = transform.up;
		} 
		else if (HorizAxis) {
			axis = transform.right;
		}
	}
	void Update () {
		if (MoveRight) {
			pos += transform.right * Time.deltaTime * MoveSpeed;
			transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
		}
		else if (MoveLeft) {
			pos += -transform.right * Time.deltaTime * MoveSpeed;
			transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
		}
		else if (MoveUp) {
			pos += transform.up * Time.deltaTime * MoveSpeed;
			transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
		}
		else if (MoveDown) {
			pos += -transform.up * Time.deltaTime * MoveSpeed;
			transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
		}
	}
}




