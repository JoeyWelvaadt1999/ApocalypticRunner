using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

	[SerializeField] private GameObject Bomb;
	[SerializeField] private Transform Spawnpoint;
	[SerializeField] private float spawnTime = 5f;


	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnBall", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnBall()
	{
		Instantiate(Bomb, Spawnpoint.position, Spawnpoint.rotation);
	}
}