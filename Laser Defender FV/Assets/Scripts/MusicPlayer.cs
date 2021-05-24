using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    #region Unity Defined Methods
    private void Awake()
    {
        SetUpBackgroundMusic();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Plays the background music
    /// </summary>
    private void SetUpBackgroundMusic()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
    #endregion
}
