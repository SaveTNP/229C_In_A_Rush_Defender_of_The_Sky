using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bulletPref;

	void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        target.transform.position = worldPos;

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
	}
}
