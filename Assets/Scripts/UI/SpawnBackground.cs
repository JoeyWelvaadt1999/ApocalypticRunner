using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour {
	private GameObject[] _backgrounds;
	[SerializeField]private GameObject _object;
	[SerializeField]private int _max;

	private float _height;
	private float _width;

	void Start() {
		_backgrounds = new GameObject[_max];
		_height = 2 * Camera.main.orthographicSize;
		_width = _height * Camera.main.aspect;
		for (int i = 0; i < _max; i++) {
			GameObject g = Instantiate (_object, new Vector3(Camera.main.transform.position.x + _width * i,0,0), Quaternion.identity)as GameObject;
			g.transform.position = new Vector2(g.transform.position.x, Camera.main.transform.position.y);
			_backgrounds [i] = g;
		}
	}

	void Update() {
//		_height = 2 * Camera.main.orthographicSize;
//		_width = _height * Camera.main.aspect;
		for (int i = 0; i < _max; i++) {
			if (_backgrounds [i].transform.position.x + _width / 2 < Camera.main.transform.position.x - _width / 2) {
				_backgrounds [i].transform.position = new Vector2 (Camera.main.transform.position.x + _width * (_backgrounds.Length - 1), _backgrounds[i].transform.position.y);
			}
		}
	}
}
