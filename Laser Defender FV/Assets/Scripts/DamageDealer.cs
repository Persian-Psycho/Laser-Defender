using UnityEngine;

/// <summary>
/// Determine the damage of the bullets
/// </summary>
public class DamageDealer : MonoBehaviour
{

    #region Param config

    /// <summary>
    /// The damage of the object
    /// </summary>
    [SerializeField] float Damage = 100f;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the damage of an object. 
    /// </summary>
    /// <returns></returns>
    public float GetDamage() => Damage;

    /// <summary>
    /// Destroy the object after hit
    /// </summary>
    public void Hit() => Destroy(gameObject);
    #endregion
}
