using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;

	void Start ()
	{
		offset = transform.position;
	}
	// Update is called once per frame
	void LateUpdate () {
	
		transform.position = player.transform.position + offset;

		//Vector2 PosofPlayer = GameObject.Find(Player).transform.position;
		//PosofPlayer = GameObject.Find(Player).GetComponent(); 
		//Vector3 bar = PosofPlayer.position;
	}
}
