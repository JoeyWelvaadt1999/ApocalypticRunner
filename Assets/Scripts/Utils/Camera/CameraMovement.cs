using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	[SerializeField]private GameObject _target;
	[SerializeField]private float _min;
	[SerializeField]private float _max;

	void Update() {
		
		transform.position = Vector3.MoveTowards (new Vector3 (transform.position.x, transform.position.y, transform.position.z), new Vector3 (_target.transform.position.x, _target.transform.position.y, transform.position.z), 0.3f);
		Vector3 pos = transform.position;
		pos.y = Mathf.Clamp(transform.position.y, _min, _max);
		transform.position = pos;
//		if (transform.position.y > 5f) {
//			if (Camera.main.orthographicSize < 7) {
//				Camera.main.orthographicSize += Time.deltaTime;
//			}
//		} else {
//			if (Camera.main.orthographicSize > 5) {
//				Camera.main.orthographicSize -= Time.deltaTime;
//			} else {
//				Camera.main.orthographicSize = 5;
//			}
//		}

	}
}
