using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	[SerializeField]private GameObject _endMenu;

	void Start() {
		PlayerGlobal.IsDeath = false;
		PlayerGlobal.PlayerSpeed = 4.0f;
	}

	void Update () {
		CheckIfDeath ();
	}

	private void CheckIfDeath() {

		if (transform.position.y < -3 && !PlayerGlobal.IsDeath) {
			PlayerGlobal.IsDeath = true;
			_endMenu.SetActive (true);
		}
	}
}
