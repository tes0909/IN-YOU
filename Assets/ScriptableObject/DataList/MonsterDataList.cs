using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "SO/ItemDataList", order = 0)]
public class MonsterDataList : ScriptableObject
{
    public List<MonsterEntity> MonsterList;

    public static ScriptableObject Convert(Sheet sheet)
    {
        MonsterDataList monsterDataList = ScriptableObject.CreateInstance<MonsterDataList>();

        if (sheet is MonsterSheets monsterSheets)
        {
            monsterDataList.MonsterList = monsterSheets.MonsterList;
        }

        return monsterDataList;
    }
}