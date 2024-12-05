using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCollider : MonoBehaviour
{
    public PolygonCollider2D polygonCollider; // The Polygon Collider 2D
    public Transform player; // The player's Transform
    public float bufferHeight = 10f; // Y-axis buffer to control the collider's range

    void Update()
    {
        if (polygonCollider == null || player == null) return;

        // Get the current points of the PolygonCollider2D
        Vector2[] points = polygonCollider.points;

        // Adjust the y-coordinates based on the player's position and buffer
        points[0].y = player.position.y - bufferHeight; // Bottom left
        points[1].y = player.position.y + bufferHeight; // Top left
        points[2].y = player.position.y + bufferHeight; // Top right
        points[3].y = player.position.y - bufferHeight; // Bottom right

        // Apply the updated points back to the PolygonCollider2D
        polygonCollider.points = points;
    }
}
