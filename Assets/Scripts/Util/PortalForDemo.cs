using UnityEngine;

public class PortalForDemo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            Managers.Scene.LoadNextScene();
    }
}
