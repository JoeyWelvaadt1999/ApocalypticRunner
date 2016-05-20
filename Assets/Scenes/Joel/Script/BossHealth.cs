using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
	[SerializeField] private float MaxHealth = 100f;
	[SerializeField] private float CurrentHealth;


	// Use this for initialization
	void Start () 
	{
		CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CurrentHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void DecreaseHealth()
	{
		CurrentHealth -= 10f;
		float calc_Health = CurrentHealth / MaxHealth;
	}
}
