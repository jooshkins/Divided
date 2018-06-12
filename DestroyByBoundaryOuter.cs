using UnityEngine;

public class DestroyByBoundaryOuter : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other) {

			Destroy (other.gameObject);
		}
}
