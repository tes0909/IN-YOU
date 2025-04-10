using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    public PlayerStatData playerStatData;
    private Slider healthBar;
    private TextMeshProUGUI healthText;
    
    private float currentHealth;
    private float maxHealth;
    public bool IsDie;

    private void OnEnable()
    {
        UIHealth.UIReady += HealthUI;
    }

    private void OnDisable()
    {
        UIHealth.UIReady -= HealthUI;
    }

    private void Start()
    {
        IsDie = false;
    }

    private void HealthUI(Slider bar, TextMeshProUGUI text)
    {
        healthBar = bar;
        healthText = text;
        currentHealth = playerStatData.CurrentHealth;
        maxHealth = playerStatData.MaxHealth;
        HpUpdateUI();
    }

    private void HpUpdateUI()
    {
        if (healthBar != null && healthText != null)
        {
            healthBar.value = currentHealth / maxHealth;
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsDie) return;
        
        currentHealth -= damage;
        Debug.Log($"플레이어가 {damage}의 공격을 받았습니다. 현재 체력: {currentHealth}");

        HpUpdateUI();

        if (currentHealth <= 0)
        {
            IsDie = true;
            Managers.UI.ShowPopupUI<UIGameOverPopup>();
            Debug.Log("사망");
        }
    }
}
