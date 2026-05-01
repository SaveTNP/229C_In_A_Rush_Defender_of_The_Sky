using UnityEngine;

public class Invincibleitem : Item
{
	protected override void ApplyEffect(GameObject player)
	{
		var status = player.GetComponent<StatusManager>();
		if (status != null) status.SetInvincible(5f);
	}
}
