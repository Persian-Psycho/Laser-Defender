using TMPro;
using UnityEngine;

public class ScoreToDisplay : MonoBehaviour
{
    #region Private Members

  
    private GameSession mGameSession;


    #endregion
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
}
