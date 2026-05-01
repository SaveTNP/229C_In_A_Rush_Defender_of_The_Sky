using UnityEngine;

public class HeavyBulletItem : Item
{
	[SerializeField] private Rigidbody2D heavyBulletPref;
	protected override void ApplyEffect(GameObject player)
	{
		var shooter = player.GetComponent<Shooter>();
		if (shooter != null) shooter.ChangeBullet(heavyBulletPref, 5f);
	}
}
