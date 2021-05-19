using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> WaveConfigs;
    [SerializeField] bool Looping = false;
    private int mStartingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllEnemies());
        } while (Looping);
    }

    private IEnumerator SpawnAllEnemies()
    {
        for (int waveIndex = mStartingWave; waveIndex < WaveConfigs.Count; waveIndex++)
        {
            var currentWave = WaveConfigs[waveIndex];
            yield return StartCoroutine(SpawnEnemy(currentWave));
        }
    }


    private IEnumerator SpawnEnemy(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfEnemy(); i++)
        {
            var newEnemy = Instantiate(
           wave.GetEnemyPrefab(),
           wave.GetEnemyWaypoints()[0].transform.position,
           Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);

            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }
}
