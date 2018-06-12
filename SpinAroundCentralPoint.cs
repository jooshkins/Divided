using UnityEngine;

public class SpinAroundCentralPoint : MonoBehaviour {

	public Vector3 point;
	public bool beenHit;
	public float speed;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Boundary") {
			return;
		}
		else {
		beenHit = true;
		}
	}
		// If I want a delay I will need to use a coroutine instead of a function
	void Update () {

		if (beenHit){
			return;
		}
		transform.RotateAround(point, Vector3.forward, 20*Time.deltaTime * speed);
	}
}

