using UnityEngine;

public class DamDealer : MonoBehaviour
{
    [SerializeField] private float dmgAmount = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DealDam(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DealDam(collision.gameObject);
    }

    private void DealDam(GameObject target)
    {
        HP targetHP = target.GetComponent<HP>();

        if (targetHP != null)
        {
            targetHP.TakeDamage(dmgAmount);

            //if (gameObject.CompareTag("Bullet"))
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
