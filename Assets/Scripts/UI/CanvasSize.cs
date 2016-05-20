using UnityEngine;
using System.Collections;

public class CanvasSize : MonoBehaviour {
	[SerializeField]private Canvas _canvas;
	[SerializeField]private float _scaleX;
	[SerializeField]private float _scaleY;
	private RectTransform _rect;
	// Use this for initialization
	void Start () {
		_rect = GetComponent<RectTransform> ();
		float x = _rect.rect.width + _canvas.pixelRect.width - (_canvas.pixelRect.width / _scaleX);
		float y = _rect.rect.height + _canvas.pixelRect.height - (_canvas.pixelRect.height / _scaleY);
		_rect.sizeDelta = new Vector2 (x, y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
