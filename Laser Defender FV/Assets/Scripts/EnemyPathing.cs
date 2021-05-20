using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Start implementing each waveconfigs and move enemies over waypoints.
/// </summary>
public class EnemyPathing : MonoBehaviour
{
    #region Private Members

    /// <summary>
    /// The list of all waypoints that the enemy must pass through them
    /// </summary>
    private List<Transform> mWaypoints;

    /// <summary>
    /// The waveconfig that determine how the enemy movement must be done.
    /// </summary>
    public WaveConfig waveConfig {  set; private get; }

    /// <summary>
    /// Determine the index of the waypoint
    /// </summary>
    private int CurrentEnemyIndex=0;

    #endregion

    #region Unity Default funcs

    /// <summary>
    /// The start function
    /// </summary>
    private void Start()
    {
        //Collect the list of waypoints from associated waveconfig
        this.mWaypoints = waveConfig.GetEnemyWaypoints();

        //Set the position of the enemy.
        transform.position = mWaypoints[CurrentEnemyIndex].position;
    }

    /// <summary>
    /// The Update functionality
    /// </summary>
    private void Update()
    {
        MoveEnemy();
    }
    #endregion

    #region Private Methods

    /// <summary>
    /// Deals with the Enemy movement.
    /// </summary>
    private void MoveEnemy()
    {
        if (CurrentEnemyIndex <= mWaypoints.Count - 1)
        {
            transform.position = Vector2.MoveTowards(
             transform.position,
             mWaypoints[CurrentEnemyIndex].transform.position,
             waveConfig.GetEnemySpeed() * Time.deltaTime);

            //Make sure that the movement is complete.
            if (transform.position == mWaypoints[CurrentEnemyIndex].transform.position) CurrentEnemyIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
