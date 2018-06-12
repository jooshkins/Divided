using UnityEngine;
using System.Collections;

public class StopCameraRotation : MonoBehaviour {

	// Update is called once per frame
	float lockPos = 0;
	void Update() { transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.z, lockPos, lockPos); }
	
}

