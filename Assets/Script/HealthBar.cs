using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Slider hpSlider;
	[SerializeField] private HP playerHP;

	private void OnEnable()
	{
		playerHP.OnHealtChanged += UpdateHPBar;
	}

	private void OnDisable()
	{
		playerHP.OnHealthChange -= UpdateHPBar;
	}

	void UpdateHPBar(float currentHP, float maxHP)
	{
	 hpSlider.value = currentHP / maxHP;
	}
}
