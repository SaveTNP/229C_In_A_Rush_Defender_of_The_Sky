using UnityEngine;

public class Heal : Item
{
	protected override void ApplyEffect(GameObject player)
	{
		HP playerHP = player.GetComponent<HP>();
		if (playerHP != null)
		{
			float healAmount = playerHP.maxHP * 0.3f;
			playerHP.TakeDamage(-healAmount);
		}
	}
}
