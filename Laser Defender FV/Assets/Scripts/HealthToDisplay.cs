using TMPro;
using UnityEngine;

/// <summary>
/// Display the score on a textmesh
/// </summary>
public class HealthToDisplay : MonoBehaviour
{
    #region Private Members

    /// <summary>
    /// The active player 
    /// </summary>
    private Player mPlayer;

    #endregion

    #region Unity Defined Methods

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = FindObjectOfType<Player>();
        GetComponent<TextMeshProUGUI>().text = mPlayer.GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = mPlayer.GetHealth().ToString();
    }

    #endregion
}
