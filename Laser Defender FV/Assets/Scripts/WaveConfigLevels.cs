using System.Collections.Generic;
using UnityEngine;

public class WaveConfigLevels : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> WaveConfigs;
  
    public List<WaveConfig> GetWaveConfigs() => WaveConfigs;

}
