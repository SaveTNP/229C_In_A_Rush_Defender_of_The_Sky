using UnityEngine;

public abstract class Item : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			ApplyEffect(collision.gameObject);
			Destroy(gameObject);
		}
	}
	protected abstract void ApplyEffect(GameObject player);
}
