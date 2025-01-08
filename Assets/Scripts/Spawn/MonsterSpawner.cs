using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    private List<List<Vector3>> spawnPoints;
    private Dictionary<int, GameObject> WorldMonster;
    public static List<int> pointNum = new List<int>();

    private int Identifier;
    public int pointGroup;
    public int monsterID;
    public int monsterCount;

    public int spawnCount { get; private set; }
    [SerializeField] private float spawnTime = 5.0f;

    public void Initialize(LevelContainer levelContainer)
    {
        spawnPoints = new List<List<Vector3>>();
        List<Vector3> spawnPointsInner;
        foreach (MonsterSpawnPointGroup spawnPointGroup in levelContainer.MonsterSpawnPoints)
        {
            spawnPointsInner = new List<Vector3>();
            foreach (Transform transform in spawnPointGroup.Points)
            {
                spawnPointsInner.Add(transform.position);
            }
            spawnPoints.Add(spawnPointsInner);
            pointNum.Add(spawnPointsInner.Count);
        }

        WorldMonster = new Dictionary<int, GameObject>();
    }

    public GameObject Spawn(string prefabPath, Transform parent = null)
    {
        string name = prefabPath.Substring(prefabPath.LastIndexOf('/') + 1);
        if (prefabPath.StartsWith("/"))
            prefabPath = prefabPath.Substring(1);

        GameObject prefab = Managers.Resource.Load<GameObject>($"Prefabs/{prefabPath}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {prefabPath}");
            return null;
        }

        return prefab;
    }

    private void SpawnEntity(int pointGroup, int point, int monsterID)
    {
        GameObject go = Spawn("/Monster");
        if (go == null)
        {
            return;
        }

        Monster monster = go.GetComponent<Monster>();
        if (monster == null)
        {
            Despawn(go);
            return;
        }

        Identifier++;
        Vector3 spawnPoint = spawnPoints[pointGroup][point];
        spawnPoint += new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0 );
        if (monster.Initialize(Identifier, monsterID, spawnPoint) == false)
        {
            Despawn(go);
            return;
        }

        monster.OnDead += Die;
        spawnCount++;
        WorldMonster.Add(Identifier, go);
    }

    private void Despawn(GameObject go)
    {
        GameObject.Destroy(go);
    }

    //NevMash 사용해서 스폰이 가능한 곳에서만 스폰 될 수 있도록 할 것
    public void MonsterSpawn()
    {
        for (int i = 0; i < pointNum[pointGroup]; i++)
        {
            SpawnEntity(pointGroup, i, monsterID);
        }
    }

    private void Die(int identifier)
    {
        spawnCount--;
        Debug.Log(identifier);
    }

    private IEnumerator SpawnMonsters()
    {
        while (spawnCount < 5.0f)
        {
            MonsterSpawn();
        }
        yield return 5.0f;
    }

    public void StartMonsterSpawn()
    {
        StartCoroutine(SpawnMonsters());
    }
}
