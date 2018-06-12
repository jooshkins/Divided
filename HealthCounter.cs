using UnityEngine;

public class HealthCounter : MonoBehaviour {

	private PlayerHealth playerHealth;

	void Start () {
		// Setting up the reference.
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	void Update () {
		// Set the health text.
		if (!(GameObject.FindGameObjectWithTag("Player"))) {
			GetComponent<GUIText>().text = "Health: 0";
		}
		else {
			GetComponent<GUIText>().text = "Health: " + playerHealth.health;
		}
	}
}
