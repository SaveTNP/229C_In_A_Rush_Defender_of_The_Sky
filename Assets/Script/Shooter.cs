using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
	[SerializeField] private Rigidbody2D defaultBullet;
	private float bulletTimer;
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bulletPref;

	private void Start()
	{
		Cursor.visible = false;
	}
	public void ChangeBullet(Rigidbody2D newBullet, float duration)
	{
		bulletPref = newBullet;
		bulletTimer = Time.time + duration;
	}

	void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        target.transform.position = worldPos;
		if (bulletPref != defaultBullet && Time.time > bulletTimer)
		{
			bulletPref = defaultBullet;
		}

		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			
			Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			target.transform.position = mouseWorldPos;
			Vector2 projectileVelocity = CalculateLinearVelocity(shootPoint.position, mouseWorldPos, 20f);
			Rigidbody2D shootBullet = Instantiate(bulletPref, shootPoint.position, Quaternion.identity);
			shootBullet.linearVelocity = projectileVelocity;
			shootBullet.transform.up = projectileVelocity;
		}


		Vector2 CalculateLinearVelocity(Vector2 origin, Vector2 target, float speed)
		{
			Vector2 direction = target - origin;

			return direction.normalized * speed;
		}

		if(Keyboard.current.escapeKey.wasPressedThisFrame)
		{
			Cursor.visible = true;
		}
	}
}
