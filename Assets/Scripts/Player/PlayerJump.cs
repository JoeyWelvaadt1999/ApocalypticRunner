using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	[SerializeField]private AudioClip _jump;
	[SerializeField]private AudioClip _land;
	[SerializeField]private Image _thruster;
	[SerializeField]private GameObject _smoke;
	private float _force;
	private float _maxForce = 1.5f;
	private Rigidbody2D _rigidbody;
	private Animator _anim;
	private AudioSource _audioSource;
	private bool _landed = true;


	void Start() {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_anim = GetComponent<Animator> ();
		_audioSource = GetComponent<AudioSource> ();
	}

	void Update() {
		_thruster.fillAmount = 1f / _maxForce * _force;
		if (Input.GetMouseButton (0)) {
			if (_force < _maxForce) {
				_force += 0.05f;

			}
		} else if (Input.GetMouseButtonUp(0) && IsGrounded ()) {
			
			_audioSource.PlayOneShot (_jump);
			GetComponent<BoxCollider2D>().isTrigger = true;
			_rigidbody.gravityScale = 0;
			Vector2 v2 = _rigidbody.velocity;
			v2.y += _force * 10;

			_rigidbody.velocity = v2;
			StartCoroutine (ResetThruster());

		}


		#region SetAnimation
		if (IsGrounded() && _rigidbody.velocity.y == 0) {
			_anim.SetBool ("Running", true);
			_anim.SetBool ("Jumping", false);
			_anim.SetBool ("Falling", false);
			if(!_landed) {
				_audioSource.PlayOneShot (_land);
				Instantiate(_smoke, new Vector2(Physics2D.Raycast (transform.position, Vector2.down, 1f, LayerMask.GetMask ("Ground")).point.x, Physics2D.Raycast (transform.position, Vector2.down, 1f, LayerMask.GetMask ("Ground")).point.y + 0.2f), Quaternion.identity);
				_landed = true;
			}

		} else if (_rigidbody.velocity.y > 0 && !IsGrounded()) {
			_anim.SetBool ("Running", false);
			_anim.SetBool ("Jumping", true);
			_anim.SetBool ("Falling", false);

		} else if( _rigidbody.velocity.y < 0 && !IsGrounded()) {
			_anim.SetBool ("Running", false);
			_anim.SetBool ("Jumping", false);
			_anim.SetBool ("Falling", true);
			GetComponent<BoxCollider2D>().isTrigger = false;

		}
		#endregion

	}

	IEnumerator ResetThruster() {
		while (_force > 0){
			_force -= 0.2f;
			if (_force < 0) {
				_force = 0;
			}
			yield return 0;
		}
		_rigidbody.gravityScale = 2.5f;
		_landed = false;

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.gameObject.layer == LayerMask.GetMask("Ground")) {
			Debug.Log ("ik heb hier geen zin meer in");
		}
	}

	bool IsGrounded() {
		
		return Physics2D.Raycast (transform.position, Vector2.down, 1f, LayerMask.GetMask ("Ground"));
	}
}
