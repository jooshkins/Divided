using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {

		if (other.tag == "Player") {
			Destroy(other.gameObject);
		}
	}
}
