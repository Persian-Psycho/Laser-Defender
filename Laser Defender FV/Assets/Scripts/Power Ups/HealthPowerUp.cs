using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] float Health = 100f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player =other.GetComponent<Player>();


        if (!player) return;

        player.AddHealth(Health);

        Destroy(gameObject);
    }
}
