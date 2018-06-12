using UnityEngine;

public class DestroyByColor : MonoBehaviour {

    public Color targetcolor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.name == "Player") && (other.GetComponent<Renderer>().material.color != targetcolor) )
        {
            Destroy(other.gameObject);
        }
        else
        {
            return;
        }
    }
}
