using UnityEngine;

public class Bullet : MonoBehaviour
{

	[SerializeField]private float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
		HP targetHP = collision.gameObject.GetComponent<HP>();

		if (targetHP != null)
		{
			targetHP.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP targetHP = collision.gameObject.GetComponent<HP>();

        if(targetHP != null)
        {
            targetHP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
