using System.Collections;
using UnityEngine;

public class MoveAtPlayerAnim : MonoBehaviour {

    public float speedMutiplier;
    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;
    private Vector2 playerPosition;
    private Vector2 enemyPosition;
    public Vector2 directionOfTravel;
    private Vector3 frameVelocity;
    private bool move;
    public float moveWait;

    void Awake() {
        // Setting up references.
        m_Anim = GetComponent<Animator>();
        frameVelocity.Set(2, 1, 2);
        m_Anim.SetFloat("speed", 0);
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Vector3 playerPosition = other.GetComponent<Rigidbody2D>().position;
        Vector3 enemyPosition = transform.position;
        directionOfTravel = playerPosition - enemyPosition;
        directionOfTravel.Normalize();
        move = true;
        StartCoroutine("Move");
    }

    void OnTriggerStay2D(Collider2D other) {

        if (other.tag == "PlayerBody") {
            //move towards the center of the world (or where ever you like)
            Vector3 playerPosition = other.GetComponent<Rigidbody2D>().position;
            Vector3 enemyPosition = transform.position;
            //first, check to see if we're close enough to the target
            if (Vector3.Distance(playerPosition, enemyPosition) > .1f) {
                directionOfTravel = playerPosition - enemyPosition;
                transform.up = playerPosition - transform.position;
            }

            if (Vector3.Distance(playerPosition, enemyPosition) < .1f) {
                 m_Anim.SetFloat("speed", 0);
                StopCoroutine("Move");
                move = false;
            }
        }
    }

    IEnumerator Move() {
        while (move) {
            directionOfTravel.Normalize();
            m_Rigidbody2D.AddForce(directionOfTravel * 10 * speedMutiplier);
            print(directionOfTravel * 10 * speedMutiplier);
            m_Anim.SetFloat("speed", m_Rigidbody2D.velocity.magnitude);
            yield return new WaitForSeconds(moveWait);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "PlayerBody") {
            m_Anim.SetFloat("speed", 0);
            move = false;
            StopCoroutine("Move");
        }
    }
}




