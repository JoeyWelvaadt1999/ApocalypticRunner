using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private bool _autoMove;
	private float _speed = 3;
	private float _speedTimer = 3.0f;
	private float _temp;

	void Update () {
		#region Auto Move
		if(_autoMove) {
			transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
			_temp += Time.deltaTime;
			if(_temp >= _speedTimer) {
				_speed += 0.1f;
				_temp = 0;
			}
		}
		#endregion

		#region Self Move 
		if(!_autoMove) {
			float x = Input.GetAxis("Vertical");

			transform.position = new Vector2(transform.position.x + x * _speed * Time.deltaTime, transform.position.y);
		}
		#endregion
	}
}
