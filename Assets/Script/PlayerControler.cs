using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
	[SerializeField] public float speed = 5.0f;
	private float moveValueX;
    private float moveValueY;
    private Vector2 moveInput;
	private Rigidbody2D _rb;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
		Vector2 mousePosScreen = Mouse.current.position.ReadValue();
		Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, 10f));
		Vector2 direction = mousePosWorld - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90f));

		if (Keyboard.current != null)
        {
            moveValueX = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f :0);
            moveValueY = (Keyboard.current.wKey.isPressed ? 1f : 0) - (Keyboard.current.sKey.isPressed ? 1f : 0);
            moveInput = new Vector2(moveValueX, moveValueY).normalized;
        }
		_rb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
	}
}
