using UnityEngine;

public class RandomColor : MonoBehaviour {
	void FixedUpdate ()
	{
		GetComponent<Renderer>().material.color = RandomColour();
	}
	
	private Color RandomColour()
	{
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;
		
		return new Color(r, g, b);
	}
}
