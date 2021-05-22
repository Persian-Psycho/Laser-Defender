using TMPro;
using UnityEngine;

public class HealthToDisplay : MonoBehaviour
{
    #region Private Members


    private Player mPlayer;


    #endregion
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
}
