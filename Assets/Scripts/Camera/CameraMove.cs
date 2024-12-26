using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }
}
