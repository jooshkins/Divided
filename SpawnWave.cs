using UnityEngine;
using System.Collections;

public class SpawnWave : MonoBehaviour
{
	public GameObject enemy;
	public float spawnnerSize;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float speed;
	public Vector2 targetPosition;
    public bool horizontal;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{

                if (horizontal) {
                    Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(transform.position.y - spawnnerSize, transform.position.y + spawnnerSize), transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemyInstance;
                    enemyInstance = Instantiate(enemy, spawnPosition, spawnRotation) as GameObject;
                    enemyInstance.GetComponent<Rigidbody2D>().AddForce(targetPosition * speed * 5000);
                    }
        
                else {
                    Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - spawnnerSize, transform.position.x + spawnnerSize), transform.position.y, transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject enemyInstance;
                    enemyInstance = Instantiate(enemy, spawnPosition, spawnRotation) as GameObject;
                    enemyInstance.GetComponent<Rigidbody2D>().AddForce(targetPosition * speed * 5000);
                }
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
