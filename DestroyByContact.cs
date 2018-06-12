using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {

		if (!(other.tag == "Player")) {
			return;
		}
		else {
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(other.gameObject);
        }
	}
}
