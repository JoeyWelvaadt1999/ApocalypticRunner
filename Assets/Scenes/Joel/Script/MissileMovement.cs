using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {
	[SerializeField] private GameObject Kabam;
	[SerializeField] private Transform THABomb;
	Animator anim;

	public float speed;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		transform.Translate (new Vector3 (0,1,0) * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ground") 
		{
			Instantiate (Kabam,THABomb.position, THABomb.rotation);
//			anim.Play ("AllahuAkbar");
			Destroy (this.gameObject);
		}
	}
}