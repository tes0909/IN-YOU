using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    private readonly HashSet<Vector3> spawnPositions = new HashSet<Vector3>();
    private float xPosition;
    private readonly float nextYposition = 20f;
    private float zPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            Vector3 spawnPosition = new Vector3(xPosition, transform.position.y + nextYposition, zPosition);
    
            if (!spawnPositions.Contains(spawnPosition))
            {
                spawnPositions.Add(spawnPosition);
                Instantiate(gridPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
