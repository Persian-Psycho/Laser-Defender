using UnityEngine;

/// <summary>
/// Generate the best fit power up
/// </summary>
public class PowerUpGenerator : MonoBehaviour
{
    #region Config Params

    [Header(header: "Power Ups")]
    [SerializeField] GameObject ShieldPowerUp;
    [SerializeField] GameObject HealthPowerUp;
    [SerializeField] GameObject HighDamagePowerUp;
    
    [Header(header:"Power Probability")]
    [Range(0, 20)] [SerializeField] float HighDamageProbability = 0;
    [Range(21, 55)] [SerializeField] float HealthProbability = 0;
    [Range(56, 100)] [SerializeField] float ShieldProbability = 0;

    #endregion

    #region Public Properties

    /// <summary>
    /// Perform the power selection based on their probabilty
    /// </summary>
    /// <returns>The selected power.</returns>
    public GameObject SelectTheRightPower()
    {
        var r = Random.Range(0, 100);

        if (IsHighDamageProbability(r))
        {
            return HighDamagePowerUp;
        }
        else if (IsHealthProbability(r))
        {
            return HealthPowerUp;
        }
        else if (IsShieldProbability(r))
        {
            return ShieldPowerUp;
        }
        else return null;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Determine whether the Shield probability occurs
    /// </summary>
    /// <param name="random">the random number</param>
    /// <returns>The result of probability occurance</returns>
    private bool IsShieldProbability(int random) => random < ShieldProbability;

    /// <summary>
    /// Determine whether the Health probability occurs
    /// </summary>
    /// <param name="random">the random number</param>
    /// <returns>The result of probability occurance</returns>
    private bool IsHealthProbability(int random) => random < HealthProbability;

    /// <summary>
    /// Determine whether the HighDamage probability occurs
    /// </summary>
    /// <param name="random">the random number</param>
    /// <returns>The result of probability occurance</returns>
    private bool IsHighDamageProbability(int random) => random < HighDamageProbability;

    #endregion
}
