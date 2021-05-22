using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetUpBackgroundMusic();
    }

    private void SetUpBackgroundMusic()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
