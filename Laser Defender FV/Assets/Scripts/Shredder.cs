using UnityEngine;

public class Shredder : MonoBehaviour
{
    /// <summary>
    /// Destroy all objects that passes through the shredder.
    /// </summary>
    /// <param name="other">The object that needs to be destroyed.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
