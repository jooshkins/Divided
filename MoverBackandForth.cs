using UnityEngine;

public class MoverBackandForth : MonoBehaviour {
	
	public Vector3 target;
	public float speed;
	private Vector3 startPosition;
	private bool hitTarget;

	void Awake () {
		startPosition = transform.position;
		hitTarget = false;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position == target) {
			hitTarget = true;
		}
		else if (transform.position == startPosition) {
			hitTarget = false;
		}
		if (hitTarget) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, startPosition, step);
		} 
		else {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
	}
}
