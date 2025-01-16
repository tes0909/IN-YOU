using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    public PlayerStatData playerStatData;
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    public event Action OnDead;
    public bool IsDie;

    private float currentHealth;
    private float maxHealth;

    private void Start()
    {
        IsDie = false;
        currentHealth = playerStatData.CurrentHealth;
        maxHealth = playerStatData.MaxHealth; 
    }

    private void Update()
    {
        HpUpdate();
    }

    public void HpUpdate()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"플레이어가 {damage}의 공격을 받았습니다. 현재 체력: {currentHealth}");

        if (currentHealth < 0)
        {
            IsDie = true;
            Managers.UI.ShowPopupUI<UIGameOverPopup>();
            Debug.Log("사망");
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.0f); // 몬스터 충돌 영역
    }
}
