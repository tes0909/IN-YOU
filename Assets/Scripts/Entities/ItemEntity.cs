using System;
using System.Collections.Generic;

[Serializable]
public class ItemEntity : EntityBase
{
    public Defines.ItemType itemType;
    public string dropPrefabPath;
    public string iconPath;

    public ItemEquipableEntity equipableEntity;
    public List<ItemConsumableEntity> consumableEntities;
}

[Serializable]
public class ItemEquipableEntity
{
    public int itemId;
    public string equippedPrefabPath;
}

[Serializable]
public class ItemConsumableEntity
{
    public int itemId;
    public Defines.ItemConsumableType consumableType;
    public float amount;
    public float duration;
    public Defines.CalcType calcType;
}