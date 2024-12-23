using System;
using System.Collections.Generic;

[Serializable]
public class MonsterEntity : EntityBase
{
    public string prefabPath;
    public string iconPath;

    public float colliderRadius;
    public float colliderHeight;

    public float maxHp;
    public float moveSpeed;

    public float attractDistance;
    public float chasePeriod;

    public float attackDamage;
    public float attackPeriod;
    public float duration;
    public float waitTime;
}
