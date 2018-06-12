using UnityEngine;
using System.Collections;

public class SquashPlayer : MonoBehaviour {
	
	//Transform playerTrans;
	public float intensity;
	private Rigidbody2D rb;
	private float velX;
	private float velY;
	private float squash;
	private float xScale;
	private float yScale;
	private float originalScale;
	private Quaternion directionTraveling;

	private Transform transformNew;

	void Start ()
	{
		//playerTrans = GetComponent<Transform>();
		intensity = 1;
		rb = GetComponent<Rigidbody2D>();
		originalScale = transform.localScale.x;
	}
	
	void FixedUpdate ()
	{
		velX = Mathf.Abs (rb.velocity.x);
		velY = Mathf.Abs (rb.velocity.y);
		squash = ((velY + velX) / intensity);
		yScale = ((squash / -2) + originalScale);
		xScale = (squash + originalScale);


		//directionTraveling = ((Mathf.Atan2(rb.velocity.y, rb.velocity.x)) - (90 * (Mathf.PI / 180)));

		directionTraveling = Quaternion.LookRotation(rb.velocity);


		transform.rotation = directionTraveling;
		transform.localScale = new Vector3(xScale ,yScale , 1);




//		directionTraveling = Quaternion.LookRotation(rb.velocity);
//		
//		transformNew.rotation = -directionTraveling;
//		transformNew.localScale = new Vector3(xScale ,yScale , 1);
//		
//		transformNew.rotation = directionTraveling;
//		
//		transformNew.position = transform.position;
//		
//		transform = transformNew;





		//transform.up = rb.velocity;

		//float moveHorizontal = Input.GetAxis("Mouse X");
		//float moveVertical = Input.GetAxis("Mouse Y");

		//transform.localScale = new Vector3(1 + moveHorizontal,1 + moveVertical, 1);

		//transform.localScale = new Vector3(xScale ,yScale , 1);

		//if (velY > 1) {
		//	transform.localScale += new Vector3(0, 0.1F, 0);
		//}
		//transform.localScale += new Vector3(0, 0.1F, 0);
		//transform.localScale += new Vector3(0.1F, 0, 0);


		// Using Absolute values removes flipping of sprite
		//xScale = (Mathf.Abs (squash / -2) + originalScale);
		//yScale = (Mathf.Abs(squash + originalScale));
	}
}


