using System.Collections.Generic;
using UnityEngine;

public class WaveConfigLevels : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> WaveConfigs;

    [Header(header: "Power Ups")]

    [Range(0, 25)] [SerializeField] float HighDamageProbability = 0;
    [Range(0, 65)] [SerializeField] float ShieldProbability = 0;
    [Range(0, 100)] [SerializeField] float HealthProbability = 0;

    public List<WaveConfig> GetWaveConfigs() => WaveConfigs;

    public float GetShieldProbability() => ShieldProbability;
    public float GetHealthProbability() =>  HealthProbability;
    public float GetHighDamageProbability() => HighDamageProbability;
    


}
