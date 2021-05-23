using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the list of waveconfigs and perform the enemy movement.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    #region Parameters Configuration
    /// <summary>
    /// The list of waveconfigs that needs to be managed
    /// </summary>
    [SerializeField] List<WaveConfigLevels> WaveConfigLevels;

    /// <summary>
    /// Should I repeat the list of waveconfig when it is finished?
    /// </summary>
    [SerializeField] bool Looping = false;


    [SerializeField] List<float> WaitDurationForBoss;
    #endregion

    #region Private Members

    /// <summary>
    /// Determine the index of start waveconfig.
    /// </summary>
    private int mStartingWave = 0;

    private int mStartingLevel = 0;
    #endregion

    #region Unity Default Funcs

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            mStartingLevel = 0;
            yield return StartCoroutine(SpawnAllEnemies());
        } while (Looping);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Spawn all enemies by looping over the list of waveconfigs
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnAllEnemies()
    {
        foreach(var WCs in WaveConfigLevels)
        {
            
            for (int waveIndex = mStartingWave; waveIndex < WCs.GetWaveConfigs().Count; waveIndex++)
            {
                var currentWave = WCs.GetWaveConfigs()[waveIndex];
                yield return StartCoroutine(SpawnEnemy(currentWave));
            }
        }


    }

    /// <summary>
    /// Spawn the specefic waveconfig to perform enemy movement
    /// </summary>
    /// <param name="wave">The waveconfig thats need to be followed to move an enemy.</param>
    /// <returns></returns>
    private IEnumerator SpawnEnemy(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfEnemy(); i++)
        {
            var newEnemy = Instantiate(
           wave.GetEnemyPrefab(),
           wave.GetEnemyWaypoints()[0].transform.position,
           Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().waveConfig = wave;
            if (!wave.IsBoss())
                yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
            else
            {
                mStartingLevel++;
                yield return new WaitForSeconds(WaitDurationForBoss[mStartingLevel - 1]);
            }
        }
    }


    #endregion
}
