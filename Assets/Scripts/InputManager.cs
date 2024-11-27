using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject gridPrefab;

    private float xPosition;
    private float nextYposition = 20f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y);
        direction = direction.normalized;
        
        rb.velocity = direction * 5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grid"))
        {
            Vector3 spawnPostion = new Vector3(xPosition, transform.position.y + nextYposition, 0f);
            
            Instantiate(gridPrefab, spawnPostion, Quaternion.identity); 
        }
    }
}
