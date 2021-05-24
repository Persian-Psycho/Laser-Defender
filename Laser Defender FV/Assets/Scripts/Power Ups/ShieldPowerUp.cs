using UnityEngine;

/// <summary>
/// Implemnt the Shield power (Immune the player against enemy).
/// </summary>
public class ShieldPowerUp : MonoBehaviour
{
    #region Config Params

    [SerializeField] GameObject ShieldPrefab;
    [SerializeField] float DurationOfShield = 3f;
    [SerializeField] AudioClip ShieldAudio;
    [SerializeField] float ShieldAudioVolume;

    #endregion

    #region Private Defined Methdods
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player)
        {
            player.Shield = true;
            player.ShieldPrefab = ShieldPrefab;
            player.DurationOfShield = DurationOfShield;
            AudioSource.PlayClipAtPoint(ShieldAudio, Camera.main.transform.position,ShieldAudioVolume);
        }

        Destroy(gameObject);
    }
    #endregion

}
