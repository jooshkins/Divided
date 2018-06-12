using UnityEngine;

public class BlackHole : MonoBehaviour {
		
	public float gravity;
    public bool reverse;

	void OnTriggerStay2D(Collider2D other) {

			if (other.name == "Boundary") {
				return;
			}
			//move towards the center of the world (or where ever you like)
			Vector3 currentPosition = other.GetComponent<Rigidbody2D>().position;
			
			Vector3 targetPosition = this.transform.position;
			//first, check to see if we're close enough to the target
			if(Vector3.Distance(currentPosition, targetPosition) > .3f) { 
				Vector3 directionOfTravel = targetPosition - currentPosition;
				//now normalize the direction, since we only want the direction information
				directionOfTravel.Normalize();
				//scale the movement on each axis by the directionOfTravel vector components
				
				other.transform.Translate(
					(directionOfTravel.x * gravity * Time.deltaTime),
					(directionOfTravel.y * gravity * Time.deltaTime),
					(directionOfTravel.z * gravity * Time.deltaTime),
					Space.World);
			}
		    else if (Vector3.Distance(currentPosition, targetPosition) < .3f) {
		         Destroy(other.gameObject);
		         }
	}
}
