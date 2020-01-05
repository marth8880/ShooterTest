using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float MaxHealth = 100f;
	public Explosion ExplosionPrefab;
	
	float CurHealth = 0f;

	void Start()
	{
		CurHealth = MaxHealth;
	}

	public float AddHealth(float health)
	{
		CurHealth += health;
		OnHealthChanged();

		return CurHealth;
	}

	void OnHealthChanged()
	{
		Debug.Log(CurHealth);

		if (CurHealth <= 0)
		{
			if (ExplosionPrefab != null)
			{
				OrdnanceCommon.Explode(gameObject, gameObject, ExplosionPrefab);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}