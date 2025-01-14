using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = player.position;
    }
}
