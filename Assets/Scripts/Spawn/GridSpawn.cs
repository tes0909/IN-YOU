using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    private HashSet<Vector3> spawnPositions = new HashSet<Vector3>();
    private float xPosition;
    private float nextYposition = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            Vector3 spawnPostion = new Vector3(xPosition, transform.position.y + nextYposition, 0f);
    
            if (!spawnPositions.Contains(spawnPostion))
            {
                spawnPositions.Add(spawnPostion);
                Instantiate(gridPrefab, spawnPostion, Quaternion.identity);
            }
        }
    }
}
