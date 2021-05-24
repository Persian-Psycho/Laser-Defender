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

    #region Private Members

    /// <summary>
    /// What is the inital damage
    /// </summary>
    public float InitialDamage { set; get; }

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

    /// <summary>
    /// Increase the damage
    /// </summary>
    /// <param name="increment">How much the projectile damage must be increased</param>
    public void AddDamage(float increment) => Damage += increment;

    /// <summary>
    /// Reset the damage to the initial value
    /// </summary>
    public void ResetDamge() => Damage = InitialDamage;
    #endregion
}
