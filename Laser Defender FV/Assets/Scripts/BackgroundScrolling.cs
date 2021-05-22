using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] float BackgroundScrollingSpeed = 0.5f;
    private Material mMaterial;
    private Vector2 mOffset;

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
}
