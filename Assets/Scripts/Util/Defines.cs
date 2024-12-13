using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Defines
{
    public enum SceneType
    {
        None,
        StartScene,
        Intro,
        Bar,
        News,
        Letter,
        Lab,
        Island_1,
        Island_2,
        Bridge,
        Home_1,
        Home_2,
        Boss,
        Last,
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
        MoveSpeed,
        HpRegen,
        MpRegen,
    }

    public enum UIEvent
    {
        None,
        Click,
        Pressed,
        PointerDown,
        PointerUp,
        Drag,
        BeginDrag,
        EndDrag,
    }

    public enum CalcType
    {
        Add,
        Multiply,
        Override,
    }

    public enum UIAnimationType
    {
        None,
        Bounce,
    }
}
