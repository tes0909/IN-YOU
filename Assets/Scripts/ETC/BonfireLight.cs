using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BonfireLight : MonoBehaviour
{
    public Light2D bonfireLight;
    public Transform player;
    public float maxRange = 10f; // 최대 거리
    public float maxIntensity = 1.0f; // 최대 밝기
    public float minIntensity = 0.5f; // 최소 밝기
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= maxRange)
        {
            bonfireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, distance / maxRange);
        }
        else
        {
            bonfireLight.intensity = minIntensity;
        }
    }
}
