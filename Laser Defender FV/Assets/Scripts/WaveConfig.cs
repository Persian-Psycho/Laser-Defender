using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    #region Parameters Configuration
  
    /// <summary>
    /// The Path that contains multiple waypoints
    /// </summary>
    [SerializeField] GameObject PathPrefab;

 

    /// <summary>
    /// The sprite of the Enemy
    /// </summary>
    [SerializeField] GameObject EnemyPrefab;

    /// <summary>
    /// The time between spawn enemies
    /// </summary>
    [SerializeField] float TimeBetweenSpawns=0.5f;

    /// <summary>
    /// The random factor of spawning enemies.
    /// </summary>
    [SerializeField] float RandomeSpawnFactor=0.3f;

    /// <summary>
    /// How many numbers of enemies should be spawned.
    /// </summary>
    [SerializeField] int NumberOfEnemy=5;

    /// <summary>
    /// The speed of each enemy.
    /// </summary>
    [SerializeField] float EnemySpeed=0.9f;

    [SerializeField] bool isBoss=false;
    #endregion

    #region Public Properties

    /// <summary>
    /// The sprite of the Enemy
    /// </summary>
    /// <returns></returns>
    public GameObject GetEnemyPrefab() => EnemyPrefab;

    /// <summary>
    /// The time between spawn enemies
    /// </summary>
    /// <returns></returns>
    public float GetTimeBetweenSpawns() => TimeBetweenSpawns;

    /// <summary>
    /// The random factor of spawning enemies.
    /// </summary>
    /// <returns></returns>
    public float GetRandomeSpawnFactor() => RandomeSpawnFactor;

    /// <summary>
    /// How many numbers of enemies should be spawned.
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfEnemy() => NumberOfEnemy;

    public bool IsBoss() => isBoss;

    /// <summary>
    /// The speed of each enemy.
    /// </summary>
    /// <returns></returns>
    public float GetEnemySpeed() => EnemySpeed;

    /// <summary>
    /// Gets a list of waypoints transforms
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetEnemyWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach(Transform t in PathPrefab.transform)waypoints.Add(t);

        return waypoints;
    } 

    #endregion
}
