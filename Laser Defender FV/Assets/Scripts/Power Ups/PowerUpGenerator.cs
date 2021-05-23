using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    #region Config Params

    [SerializeField] GameObject ShieldPowerUp;
    [SerializeField] GameObject HealthPowerUp;
    [SerializeField] GameObject HighDamagePowerUp;


    #endregion

    #region Public Properties

    public WaveConfigLevels CurrentWaveConfigLevel { set; private get; }

    public GameObject SelectTheRightPower()
    {
        var r = Random.Range(0, 100);

        if (IsShieldProbability(r))
        {
            return ShieldPowerUp;
        }else if (IsHealthProbability(r))
        {
            return HealthPowerUp;
        }else if (IsHighDamageProbability(r))
        {
            return HighDamagePowerUp;
        }

        return null;
    }

    
    private bool IsShieldProbability(int random) => random < CurrentWaveConfigLevel.GetShieldProbability();
    private bool IsHealthProbability(int random) => random < CurrentWaveConfigLevel.GetHealthProbability();
    private bool IsHighDamageProbability(int random) => random < CurrentWaveConfigLevel.GetHighDamageProbability();
    
    #endregion
}
