using UnityEngine;

public class SwitchPlayer : MonoBehaviour {

    public Color targetcolor;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.name == "Player"))
        {
            return;
        }
        else
        {
            other.GetComponent<Renderer>().material.color = targetcolor;
        }
    }
}
