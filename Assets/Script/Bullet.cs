using UnityEngine;

public class Bullet : MonoBehaviour
{

	[SerializeField]private float damage = 10f;
    public bool isPlayerBullet = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindWithTag("Player");
        StatusManager status = (player != null) ? player.GetComponent<StatusManager>() : null;
        float finalDamage = damage;
        if(status != null && status.IsInvincible())
        {
            finalDamage = 1000f;
        }
        if (isPlayerBullet && collision.CompareTag("Player")) return;
        if (!isPlayerBullet && collision.CompareTag("Enemy")) return;
        if (collision.CompareTag("Effector")) return;
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
