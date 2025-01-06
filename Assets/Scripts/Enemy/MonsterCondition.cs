using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterCondition : MonoBehaviour
{
    public event Action<float> OnHit;
    public event Action OnDead;

    [field: SerializeField] public bool IsDead { get; private set; }
    [field: SerializeField] public float MaxHp { get; private set; }
    [field: SerializeField] public float CurrentHp { get; private set; }

    public void SetData(float maxHp)
    {
        IsDead = false;
        MaxHp = maxHp;
        CurrentHp = MaxHp;
    }

    public void TakeDamage(float damage)
    {
        CurrentHp = Mathf.Clamp(CurrentHp - damage, 0, MaxHp);
        // 피격 이펙트
        // 피격 사운드
        if (CurrentHp <= 0)
        {
            IsDead = true;
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke(damage);
        }
    }

    public void Heal(float heal)
    {
        CurrentHp = Mathf.Clamp(CurrentHp + heal, 0, MaxHp);
    }
}
