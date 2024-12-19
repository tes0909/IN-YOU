using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;

    public Vector2 newPlayerPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = newPlayerPosition;
        }
    }
}