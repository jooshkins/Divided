using System.Collections;
using UnityEngine;

public class PlayerControllerTouch : MonoBehaviour {
    public float speed = 5f;
    public Boundary cntlboundary;
    public GameObject bullet;
    public float bulletSpeed;
    public float reload;
    private Vector2 playerPosition;
    private Vector2 spawnPosition;
    private Quaternion spawnRotation;
    private Vector2 directionOfTravel;
    private bool fired;

    void Start()
    {
        Cursor.visible = false;
    }

    IEnumerator Shoot()
    {
        while (Input.touchCount == 2)
        {
            Touch myTouch = Input.touches[1];
            Vector3 movement = new Vector3(myTouch.deltaPosition.x * .5f, myTouch.deltaPosition.y * .5f);
            spawnPosition = transform.position * 2;
            spawnRotation = Quaternion.identity;
            directionOfTravel = movement;
            directionOfTravel.Normalize();
            GameObject bulletInstance;
            bulletInstance = Instantiate(bullet, spawnPosition, spawnRotation) as GameObject;
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(directionOfTravel * 5000 * speed);
            fired = true;
            yield return new WaitForSeconds(reload);
            fired = false;
        }
    }

    void Update()
    {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);

            Vector3 movement = new Vector3(touch.deltaPosition.x * .5f, touch.deltaPosition.y * .5f);

            GetComponent<Rigidbody2D>().AddForce(movement * speed);

            GetComponent<Rigidbody2D>().position = new Vector2
            (
                    Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, cntlboundary.xMin, cntlboundary.xMax),
                    Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, cntlboundary.yMin, cntlboundary.yMax)
            );
        }

        if ((Input.touchCount == 2) && (!(fired)))
        {
            StartCoroutine("Shoot");
        }
    }
}

