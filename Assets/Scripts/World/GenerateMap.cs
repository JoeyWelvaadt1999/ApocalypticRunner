using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour {
	
	[SerializeField]private int _posY;

	[SerializeField]private Chunk[] _chunks;

	private int _maxCount = 50;
	public int BlockCount { get; set;}
	private List<GameObject> _blocks = new List<GameObject>();
	private List<GameObject> _checked = new List<GameObject> ();
	public List<GameObject> Blocks{
		get { 
			return _blocks;
		}
	}


	void Update () {
		if (BlockCount < _maxCount) {
			_chunks [Random.Range (0, _chunks.Length)].InstantiateObject (_posY, this);
		}
		DestroyBlocks ();
	}

	void DestroyBlocks() {
		float height = 2 * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;

		for (int i = 0; i < _blocks.Count; i++) {
			if(_blocks[i].transform.position.x < Camera.main.transform.position.x - width / 2){
				if (!_checked.Contains (_blocks [i])) {
					BlockCount--;
					_checked.Add (_blocks [i]);
				}
			}
		}
			
	}
}
	
