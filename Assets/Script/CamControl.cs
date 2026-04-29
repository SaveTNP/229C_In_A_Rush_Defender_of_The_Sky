using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform target;
    public float smoothness = 5f;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void LateUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.fixedDeltaTime);
        }
    }
}
