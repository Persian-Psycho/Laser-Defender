using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// perform buttons action
/// </summary>
public class Level : MonoBehaviour
{
    #region Config Params
    [SerializeField] float DelayDuration = 3f;
    #endregion

    #region Public Methods

    /// <summary>
    /// Load the game over scene
    /// </summary>
    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverWithDelay());
    }

    /// <summary>
    /// Load the gameover scene with a delay duration
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(DelayDuration);
        SceneManager.LoadScene("Gameover Scene");
    }

    /// <summary>
    /// Load the gameplay scene
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    /// <summary>
    /// Load the start scene
    /// </summary>
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
        FindObjectOfType<GameSession>().ResetScore();

    }
    /// <summary>
    /// Quit the whole game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
