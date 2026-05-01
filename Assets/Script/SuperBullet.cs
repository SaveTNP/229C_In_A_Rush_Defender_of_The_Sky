using UnityEngine;

public class SuperBulletItem : Item
{
	[SerializeField] private Rigidbody2D superBulletPref;
	protected override void ApplyEffect(GameObject player)
	{
		var shooter = player.GetComponent<Shooter>();
		if (shooter != null) shooter.ChangeBullet(superBulletPref, 5f);
	}
}