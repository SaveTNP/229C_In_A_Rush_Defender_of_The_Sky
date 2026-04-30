using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private HP playerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        playerHP.OnHealtChanged += UpdateHPBar;
    }

    private void OnDisable()
    {
        playerHP.OnHealtChanged -= UpdateHPBar;
    }
    // Update is called once per frame
    void UpdateHPBar(float currentHP, float maxHP)
    {
        healthBarSlider.value = currentHP / maxHP;
    }
}
