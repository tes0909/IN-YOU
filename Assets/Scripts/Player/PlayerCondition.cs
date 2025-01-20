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

        StartCoroutine(waitForHealth());
    }

    private IEnumerator waitForHealth()
    {
        while (GameObject.Find("@UI_Root/UIGameScene/Health") == null)
        {
            yield return null;
        }
        
        GameObject health = GameObject.Find("@UI_Root/UIGameScene/Health");
        if (health != null)
        {
            healthBar = health.transform.Find("HealthBar")?.GetComponent<Slider>();
            healthText = health.transform.Find("HealthBar/HealthText")?.GetComponent<TextMeshProUGUI>();
        }
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
}
