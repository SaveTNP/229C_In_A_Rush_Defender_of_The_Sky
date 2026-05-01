using UnityEngine;

public class StatusManager : MonoBehaviour
{
    private float invincibleTimer;
    private HP hp;
    private Bullet damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = GetComponent<HP>();
        damage = GetComponent<Bullet>();
    }

    public void SetInvincible(float duration)
    {
        invincibleTimer = Time.time + duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < invincibleTimer)
        {
            
        }
    }
    public bool IsInvincible() => Time.time < invincibleTimer;
}
