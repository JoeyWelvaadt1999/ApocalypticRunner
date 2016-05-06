using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour{
	[SerializeField]private GameObject[] _blocks;

	public void InstantiateObject(float y, GenerateMap _generateMap) {

		for (int i = 0; i < _blocks.Length; i++) {
			GameObject b = Instantiate (_blocks [i].gameObject, new Vector2((1 * _generateMap.Blocks.Count), y), Quaternion.identity) as GameObject;
			_generateMap.BlockCount++;
			b.transform.parent = _generateMap.transform;
			_generateMap.Blocks.Add (b);
		}
	}
}
