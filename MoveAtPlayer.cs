using UnityEngine;

public class MoveAtPlayer : MonoBehaviour {
    public float speed;
    private Vector2 playerPosition;
    private Vector2 enemyPosition;
    private Quaternion enemyRotation;
    private Vector2 directionOfTravel;
    private Vector3 previous;
    private Vector3 curPosition;
    public bool rotate;

    // move by translate
    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "PlayerBody")
        {
            //move towards the center of the world (or where ever you like)
            Vector3 playerPosition = other.GetComponent<Rigidbody2D>().position;

            Vector3 enemyPosition = transform.position;
            //first, check to see if we're close enough to the target
            if (Vector3.Distance(playerPosition, enemyPosition) > .1f)
            {
                Vector3 directionOfTravel = playerPosition - enemyPosition;
                //now normalize the direction, since we only want the direction information
                directionOfTravel.Normalize();
                //scale the movement on each axis by the directionOfTravel vector components

                transform.Translate(
                    (directionOfTravel.x * speed * Time.deltaTime),
                    (directionOfTravel.y * speed * Time.deltaTime),
                    (directionOfTravel.z * speed * Time.deltaTime),
                    Space.World);
                if (rotate) { transform.up = playerPosition - transform.position; }
            }
        }
    }
}
