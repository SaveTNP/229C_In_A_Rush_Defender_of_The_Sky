using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Loot
{
	public GameObject itemPrefab;
	[Range(0, 100)] public float chance;
}

public class Enemy : MonoBehaviour
{
	public List<Loot> lootTable;

	[SerializeField] private float speed = 3f;
	[SerializeField] private float minDistance = 0.5f;
	[SerializeField] private float fireRate = 1.5f;
	[SerializeField] private float bulletSpeed = 15f;
	public Transform shootPoint;
	public Transform target;
	public Rigidbody2D bulletPref;

	private float nextFire;
	private Rigidbody2D _rb;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		if(target == null){
			target = GameObject.FindWithTag("Player").transform;
		}
		_rb = GetComponent<Rigidbody2D>();
	}
	public void DropItem(){
		float roll = Random.Range(0f, 100f);
		float cumulativeChance = 0f;

		foreach (Loot loot in lootTable)
		{
			cumulativeChance += loot.chance;
			if (roll <= cumulativeChance)
			{
				if (loot.itemPrefab != null)
				{
					Instantiate(loot.itemPrefab, transform.position, Quaternion.identity);
				}
				break;
			}

		}
	}
    // Update is called once per frame
    void Update()
    {
		if (target == null)
		{
			return;
		}

		Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
		float distance = direction.magnitude;

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle +90f);

		if(distance > minDistance)
		{
			_rb.linearVelocity=direction.normalized*speed;
		}
		if (Time.time >= nextFire)
		{
			Shoot();
			nextFire = Time.time + fireRate;
		}
	}
	void Shoot()
	{
		Vector2 shootDirection = ((Vector2)target.position - (Vector2)shootPoint.position).normalized;
		Rigidbody2D bullet = Instantiate(bulletPref, shootPoint.position, Quaternion.identity);

		bullet.linearVelocity = shootDirection * bulletSpeed;
		bullet.transform.up = shootDirection;
	}
}
