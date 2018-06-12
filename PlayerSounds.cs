using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour {
	public AudioClip deathClip;
	public AudioClip winClip;
	private bool dead;
	private bool win;
	private GameObject state;
	private string stateText;

	void Start () {
		state = GameObject.Find ("State_Text_GUI");
	}

	void Update () {
		stateText = state.GetComponent<GUIText>().text;
		if ((stateText == "You Died!") & (!(dead))) {
			GetComponent<AudioSource>().PlayOneShot(deathClip, 0.7F);
			dead = true;
		}

		else if ((stateText == "You Win!") & (!(win))) {
			GetComponent<AudioSource>().PlayOneShot(winClip, 0.7F);
			win = true;
		}
	}
}
