using UnityEngine;

public class DestroyByContactSpeed : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (!(other.name == "Player"))
        {
            return;
        }
        else
        {
            Destroy(other.gameObject);
        }

    }
}
