using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    private List<Transform> mWaypoints;
    private WaveConfig waveconfig;

    //public WaveConfig TheWaveConfig {  set; private get; }
    private int CurrentEnemyIndex=0;

    public void SetWaveConfig(WaveConfig wave) => waveconfig = wave;

    private void Start()
    {
        this.mWaypoints = waveconfig.GetEnemyWaypoints();
        transform.position = mWaypoints[CurrentEnemyIndex].position;
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if(CurrentEnemyIndex <= mWaypoints.Count-1)
        {
            transform.position = Vector2.MoveTowards(
             transform.position,
             mWaypoints[CurrentEnemyIndex].transform.position,
             waveconfig.GetEnemySpeed() * Time.deltaTime);
            if (transform.position == mWaypoints[CurrentEnemyIndex].transform.position) CurrentEnemyIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
