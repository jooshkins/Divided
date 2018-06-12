using UnityEngine;
using System.Collections;

public class ShootAtPlayer : MonoBehaviour {

	public GameObject enemy;
	public float spawnWait;
	public float speed;
	private Vector2 playerPosition;
	private Vector2 spawnPosition;
	private Quaternion spawnRotation;
	private Vector2 directionOfTravel;

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name == "Player") {
			playerPosition = other.GetComponent<Rigidbody2D>().position;
			spawnPosition = this.transform.position;
			spawnRotation = Quaternion.identity;
			directionOfTravel = playerPosition - spawnPosition;
			directionOfTravel.Normalize();
			StartCoroutine ("Shoot");
		}
	}

	void OnTriggerStay2D(Collider2D other) {
	
		if (other.name == "Player") {
			playerPosition = other.GetComponent<Rigidbody2D>().position;
			spawnPosition = this.transform.position;
			spawnRotation = Quaternion.identity;
			directionOfTravel = playerPosition - spawnPosition;
			directionOfTravel.Normalize();
		}
	}

	IEnumerator Shoot () {
		while (true) {
			GameObject enemyInstance;
			enemyInstance = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject ;
			enemyInstance.GetComponent<Rigidbody2D>().AddForce(directionOfTravel * 5000 * speed);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Player") {
			StopCoroutine ("Shoot");
		}
	}
}


