using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target;
    public float smoothness = 5f;
    public Vector3 offset = new Vector3(0,0,-10);
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void LateUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        }
    }
}
