using UnityEngine;

public class GameSession : MonoBehaviour
{
    public float Score { private set; get; } = 0;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void AddScore(float score) => Score += score;

    public void ResetScore()
    {
        Score = 0;
        Destroy(gameObject);
    }
}
