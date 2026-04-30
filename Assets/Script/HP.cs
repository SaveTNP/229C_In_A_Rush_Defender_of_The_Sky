    using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;
    private float currentHP;

    public UnityAction<float, float> OnHealtChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        OnHealtChanged?.Invoke(currentHP, maxHP);

        if(currentHP < 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
