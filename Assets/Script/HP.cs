    using UnityEngine;
using UnityEngine.Events;
using System;

public class HP : MonoBehaviour
{
    [SerializeField] public float maxHP = 100f;
    public float currentHP;
	public Action<float, float> OnHealthChange;
	public UnityAction<float, float> OnHealtChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
		OnHealtChanged?.Invoke(currentHP, maxHP);
	}

    public void TakeDamage(float damage)
    {
        StatusManager inVincible = GetComponent<StatusManager>();
        if (inVincible != null && inVincible.IsInvincible())
        {
            return;
        }
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        OnHealtChanged?.Invoke(currentHP, maxHP);

        if(currentHP <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    private void Die()
    {
		KillCounter counter = FindFirstObjectByType<KillCounter>();
        Enemy loot = GetComponent<Enemy>();

		if (counter != null)
		{
			counter.KillCount();
		}
		if (loot != null)
        {
            loot.DropItem();
        }
		if (CompareTag("Player"))
		{
			FindAnyObjectByType<MenuController>().LoseScene();
		}
		Destroy(gameObject);
    }
}
