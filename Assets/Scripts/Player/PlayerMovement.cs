using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private bool _autoMove;
	private SaveScore _saveScore;
//	private float _speed = 3;
	private float _speedTimer = 2.0f;
	private float _temp;

	void Start() {
		_saveScore = FindObjectOfType<SaveScore> ();
	}

	void Update () {
		#region Auto Move
		if(_autoMove) {
			transform.position = new Vector2(transform.position.x + PlayerGlobal.PlayerSpeed * Time.deltaTime, transform.position.y);
			_temp += Time.deltaTime;
			if(_temp >= _speedTimer) {
				PlayerGlobal.PlayerSpeed += 0.1f;
				_temp = 0;
			}
		}
		#endregion

		#region Self Move 
		if(!_autoMove) {
			float x = Input.GetAxis("Vertical");

			transform.position = new Vector2(transform.position.x + x * PlayerGlobal.PlayerSpeed * Time.deltaTime, transform.position.y);
		}
		#endregion

	}
}
