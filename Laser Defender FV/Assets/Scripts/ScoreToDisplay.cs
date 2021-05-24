using TMPro;
using UnityEngine;

/// <summary>
/// Display the score
/// </summary>
public class ScoreToDisplay : MonoBehaviour
{
    #region Private Members

  
    /// <summary>
    /// The running game session
    /// </summary>
    private GameSession mGameSession;


    #endregion

    #region Unity Defined Methods

    // Start is called before the first frame update
    void Start()
    {
        mGameSession = FindObjectOfType<GameSession>();
        GetComponent<TextMeshProUGUI>().text = mGameSession.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = mGameSession.Score.ToString();
    }
    #endregion
}
