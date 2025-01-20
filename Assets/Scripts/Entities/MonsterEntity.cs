using System;
using System.Collections.Generic;

[Serializable]
public class MonsterEntity : EntityBase
{
    public string prefabPath;

    public float maxHp;
    public float moveSpeed;

    public float attractDistance;

    public float attackDamage;
    public float attackDistance;
}
