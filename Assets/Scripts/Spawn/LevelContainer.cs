using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    public Transform PlayerStartPoint;
    public List<MonsterSpawnPointGroup> MonsterSpawnPoints;
}

[Serializable]
public class MonsterSpawnPointGroup
{
    public List<Transform> Points;
}
