using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    public PlayerStatData playerStatData;
    public BugStats bugStats;
    public Slider healthBar;
    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
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
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"플레이어가 {bugStats.bugName}에게 {damage}의 공격을 받았습니다. 현재 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("사망");
        }
    }
}
