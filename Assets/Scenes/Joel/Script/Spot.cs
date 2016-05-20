using UnityEngine;
using System.Collections;

public class Spot : MonoBehaviour {

	private float _curTime; //Timer that increases until it reached its life time
	private float _lifeTime = 2.0f; //Maximum the timer can go


	void Update() {
		_curTime += Time.deltaTime;
		if (_curTime >= _lifeTime) {
			_curTime = 0; //Reset Timer
			Destroy (this.gameObject); //Destroys itself when the player waits to long to press the spot
		}
	}
	/// <summary>
	/// Checks if player has pressed the spot
	/// </summary>
	private void OnMouseDown() {
		Debug.Log ("Click");
		//This means the player has clicked inside the spot
		//do something...
		GetComponentInParent<BossHealth>().DecreaseHealth();
		Destroy(this.gameObject);

	}
}