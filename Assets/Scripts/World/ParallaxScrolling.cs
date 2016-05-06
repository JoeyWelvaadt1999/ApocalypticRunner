using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {
	[SerializeField]private float _speed;

	void Update() {
		float x = Input.GetAxis ("Horizontal");

		transform.position = new Vector2 (transform.position.x + -_speed * Time.deltaTime, transform.position.y);
	}
}
