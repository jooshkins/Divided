using UnityEngine;

public class SlowTimeOnContact : MonoBehaviour {

	public float slowTimeAmount;
	void OnTriggerStay2D (Collider2D other) {
			if (other.name == "Player") {
            Time.timeScale = 0.5F;
        }
	}
	void OnTriggerExit2D (Collider2D other) {
		Time.timeScale = 1f;
	}
}
