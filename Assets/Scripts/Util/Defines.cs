using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Defines
{
    public enum SceneType
    {
        None,
        TitleScene,
        GameScene,
        IntroScene,
    }

    public enum ItemType
    {
        None,
        Equipment,
        Consumable,
    }

    public enum ItemConsumableType
    {
        None,
        HpRecovery,
        MpRecovery,
    }

    public enum CharacterStatType
    {
        None,
        Hp,
        Mp,
        AttackDamage,
        AttackSpeed,
        MoveSpeed,
        HpRegen,
        MpRegen,
        CooltimeReduction,
    }

    public enum CalcType
    {
        Add,
        Multiply,
        Override,
    }
}
