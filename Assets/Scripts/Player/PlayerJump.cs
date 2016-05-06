using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	private float _force;
	private float _maxForce = 0.5f;
	private Rigidbody2D _rigidbody;
	private Animator _anim;

	void Start() {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_anim = GetComponent<Animator> ();
	}

	void Update() {
		if (Input.GetKey (KeyCode.Space)) {
			if (_force < _maxForce) {
				_force += Time.deltaTime * 2;
			}
		} else if (Input.GetKeyUp(KeyCode.Space) && IsGrounded()) {
			_rigidbody.AddForce (new Vector2 (0, _force * 1000));
			_force = 0;
		}

		if (_rigidbody.velocity.y == 0) {
			_anim.SetBool ("Running", true);
			_anim.SetBool ("Jumping", false);
			_anim.SetBool ("Falling", false);
		} else if (_rigidbody.velocity.y > 0) {
			_anim.SetBool ("Running", false);
			_anim.SetBool ("Jumping", true);
			_anim.SetBool ("Falling", false);
		} else {
			_anim.SetBool ("Running", false);
			_anim.SetBool ("Jumping", false);
			_anim.SetBool ("Falling", true);
		}

		Debug.Log ("Velocity" + _rigidbody.velocity.y);
	}

	bool IsGrounded() {
		return Physics2D.Raycast (transform.position, Vector2.down, 1f, LayerMask.GetMask ("Ground"));
	}
}
