using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    private List<List<Vector3>> spawnPoints;
    private Dictionary<int, GameObject> WorldMonster;
    private Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();
    public static List<int> pointNum = new List<int>();

    private int Identifier;
    public int pointGroup;
    public int monsterID;
    public int monsterCount;
    private int defaultCapacity = 10;

    public int spawnCount { get; private set; }
    [SerializeField] private float spawnTime = 5.0f;

    public void Initialize(LevelContainer levelContainer)
    {
        Debug.Log("levelcontainer Init");
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
        Debug.Log(spawnPoints.Count);
        Debug.Log(pointNum.Count);
        WorldMonster = new Dictionary<int, GameObject>();
    }

    public GameObject Spawn(string prefabPath, Transform parent = null)
    {
        Debug.Log("SpawnInit");
        string name = prefabPath.Substring(prefabPath.LastIndexOf('/') + 1);
        if (prefabPath.StartsWith("/"))
            prefabPath = prefabPath.Substring(1);

        if (poolDict.TryGetValue(name, out ObjectPool pool) == false)
        {
            GameObject prefab = Managers.Resource.Load<GameObject>($"Prefabs/{prefabPath}");
            if (prefab == null)
            {
                Debug.Log($"Failed to load prefab : {prefabPath}");
                return null;
            }
            pool = CreatePool(prefab, parent);
            Debug.Log(pool);
        }
        return pool.Pop();
    }

    private void SpawnEntity(int pointGroup, int point, int monsterID)
    {
        GameObject go = Spawn("/Monster");
        if (go == null)
        {
            Debug.Log("SpawnError");
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
        Debug.Log(pointGroup);
        Debug.Log(point);
        Debug.Log(monsterID);
        Debug.Log(spawnPoint);

        //spawnPoint += new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0 );
        if (monster.Initialize(Identifier, monsterID, spawnPoint) == false)
        {
            Despawn(go);
            return;
        }
        Debug.Log(spawnPoint);
        Debug.Log(go);
        Debug.Log(go.name);
        spawnCount++;
        WorldMonster.Add(Identifier, go);
        monster.OnDead += Die;
    }

    private void Despawn(GameObject go)
    {
        if (poolDict.TryGetValue(go.name, out ObjectPool pool))
        {
            pool.Push(go);
        }
        else
        {
            Debug.Log($"Failed to despawn : {go.name}");
            GameObject.Destroy(go);
        }
    }

    public void MonsterSpawn()
    {
        if(spawnCount < 1.0f) //6
        {
            for (int i = 0; i < 1; i++)//pointNum[pointGroup]; i++)
            {
                SpawnEntity(pointGroup, i, monsterID);
            }
        }
    }

    private void Die(int identifier)
    {
        spawnCount--;
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
        MonsterSpawn();
    }

    private ObjectPool CreatePool(GameObject prefab, Transform parent = null)
    {
        ObjectPool pool = new ObjectPool(prefab, parent, defaultCapacity);
        poolDict.Add(prefab.name, pool);
        return pool;
    }
}
