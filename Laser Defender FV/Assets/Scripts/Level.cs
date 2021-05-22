using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float DelayDuration=3f;
    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverWithDelay());
    }

    private IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(DelayDuration);
        SceneManager.LoadScene("Gameover Scene");

    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
        FindObjectOfType<GameSession>().ResetScore();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
