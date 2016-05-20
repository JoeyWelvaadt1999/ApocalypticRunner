using UnityEngine;
using System.Collections;

public class FlyAround : MonoBehaviour {

	[SerializeField] private float speed = 1f;
	private Vector3 direction;
	private int hover = 4;
	private Vector3 startPosition;

	void Start()
	{
		direction = (new Vector3( 1.0f, 0.0f, 0.0f));
		startPosition = transform.position;
	}
		
	void Update() 
	{
		if (Hit (new Vector2 (1, 0f))) {
			speed = -speed;

		}  if (Hit (new Vector2 (-1, 0f))) {
			speed = -speed;
		}
			
		transform.position += new Vector3(speed * Time.deltaTime, 0,0);
		HoverMovent ();
	}
		
	void HoverMovent()
	{
		transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * hover), transform.position.z); 
	}
		
	bool Hit(Vector2 dir) {
		Debug.DrawRay (new Vector2(transform.position.x + 2.9f * dir.x, transform.position.y), dir, Color.black, 2f);
		return Physics2D.Raycast (new Vector2(transform.position.x + 2.9f * dir.x, transform.position.y), dir, 0.5f, LayerMask.GetMask("Ground")); 
	}
}
