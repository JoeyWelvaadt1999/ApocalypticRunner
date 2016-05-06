using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	[SerializeField]private GameObject _target;

	void Update() {
		transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3(_target.transform.position.x, transform.position.y, transform.position.z), 0.1f);

	}
}
