using UnityEngine;

/// <summary>
/// Implemnt the High Damage power (Increases the damage of Player laser).
/// </summary>
public class HighDamagePowerUp : MonoBehaviour
{
    #region Config Params
    
    /// <summary>
    /// How much the player projectile damage must be increased.
    /// </summary>
    [SerializeField] float DamageIncrementFactor = 100f;
    [SerializeField] AudioClip HighDamageAudio;
    [SerializeField] float HighDamageAudioVolume;
    #endregion

    #region Private Defined Methods

    /// <summary>
    /// Perform an action when the collision occurs
    /// </summary>
    /// <param name="other">The player Spaceship.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        //Make sure that we have something to do.
        if (player)
        {
            player.IncreaseProjectileDamage(DamageIncrementFactor);
            AudioSource.PlayClipAtPoint(HighDamageAudio, Camera.main.transform.position, HighDamageAudioVolume);
        }

        Destroy(gameObject);
    }
    #endregion
}
