using UnityEngine;

public class HighDamagePowerUp : MonoBehaviour
{
    [SerializeField] float DamageIncrementFactor = 100f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (!player) return;

        player.IncreaseProjectileDamage(DamageIncrementFactor);

        Destroy(gameObject);
    }
}
