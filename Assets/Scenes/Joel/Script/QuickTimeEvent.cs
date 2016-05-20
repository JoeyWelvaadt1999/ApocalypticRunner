using UnityEngine;
using System.Collections;

public class QuickTimeEvent : MonoBehaviour {


	[SerializeField]private GameObject _spot; //The spot that has to be created
	private float _curTime; //Timer to check if waited the needed time to create a spot
	private float _spawnObject = 3.0f; //Time needed to create new spot

	void Update() {
		_curTime += Time.deltaTime;
		if (_curTime >= _spawnObject) {
			_curTime = 0; //Reset timer;
			CreateSpot();
			}
		}

	private void CreateSpot() {
		//Lets say this gameobject is 7x5 that means 700x500 pixels
		//Get random position inside gameobject to create spot

		Vector2 spotPos = new Vector2 (Random.Range(-3.5f, 3.5f), Random.Range(-2.5f, 2.5f));
		Vector2 finalPos = new Vector3 (transform.position.x + spotPos.x, transform.position.y, -2);
		GameObject spot = Instantiate (_spot, finalPos, Quaternion.identity) as GameObject;
		spot.transform.parent = transform;

	}
}