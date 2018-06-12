using UnityEngine;

public class DestroyByExplosion : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name == "Boundary") {
			return;
		}
		else {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
