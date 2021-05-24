using UnityEngine;

/// <summary>
/// Holds the user data.
/// </summary>
public class GameSession : MonoBehaviour
{

    #region Public Properties
    
    /// <summary>
    /// The score of the user
    /// </summary>
    public float Score { private set; get; } = 0;

    #endregion

    #region Unity Defined Methods
    private void Awake()
    {
        //Make sure there is only one gamesession file
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Adds score
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(float score) => Score += score;

    /// <summary>
    /// Set the score to zero
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
        Destroy(gameObject);
    }
    #endregion
}
