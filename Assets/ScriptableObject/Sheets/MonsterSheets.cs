using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(ExcelName = "MonsterSheets", AssetPath = "Resources/SO/Sheets")]
public class MonsterSheets : Sheet
{
    public List<MonsterEntity> MonsterList;
}
