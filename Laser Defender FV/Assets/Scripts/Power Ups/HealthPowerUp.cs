using UnityEngine;

/// <summary>
/// Implemnt the Health power.
/// </summary>
public class HealthPowerUp : MonoBehaviour
{
    #region Config Params
    /// <summary>
    /// How much health the player receive
    /// </summary>
    [SerializeField] float Health = 50f;

    [SerializeField] AudioClip HealthAudio;
    [SerializeField] float HealthdAudioVolume;
    #endregion


    #region Private Defined Methods

    /// <summary>
    /// Perform an action when the collision occurs
    /// </summary>
    /// <param name="other">The player Spaceship.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        //Make sure it is a player and its not a shreder.
        if (player)
        {
            player.AddHealth(Health);
            AudioSource.PlayClipAtPoint(HealthAudio, Camera.main.transform.position, HealthdAudioVolume);
        }

        Destroy(gameObject);
    }
    #endregion
}
