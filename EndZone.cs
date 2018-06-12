using UnityEngine;

public class EndZone : MonoBehaviour {

	private GameObject stateTextGUI;

	// Use this for initialization
	void Start () {
		// Setting up the reference.
		stateTextGUI = GameObject.Find("State_Text_GUI");
}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			stateTextGUI.GetComponent<GUIText>().text = "You Win!";
			Destroy(other.gameObject);
		}
	}
}
