using UnityEngine;

/// <summary>
/// Scrolls the background image
/// </summary>
public class BackgroundScrolling : MonoBehaviour
{
    #region Config Params
    
    /// <summary>
    /// The speed of repeating the backgroung
    /// </summary>
    [SerializeField] float BackgroundScrollingSpeed = 0.5f;
    #endregion

    #region Private Members

    /// <summary>
    /// The material that contains the bacground sprite and needs to be repeated
    /// </summary>
    private Material mMaterial;

    /// <summary>
    /// The offset
    /// </summary>
    private Vector2 mOffset;

    #endregion

    #region unity Defined Methods

    // Start is called before the first frame update
    void Start()
    {
        mMaterial = GetComponent<Renderer>().material;
        mOffset = new Vector2(0f, BackgroundScrollingSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        mMaterial.mainTextureOffset += mOffset * Time.deltaTime;
    }
    #endregion
}
