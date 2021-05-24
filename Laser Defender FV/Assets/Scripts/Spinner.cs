using UnityEngine;

/// <summary>
/// Spin an object over Z  axis
/// </summary>
public class Spinner : MonoBehaviour
{
    [SerializeField] float SpeedOfSpinner = 180f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, SpeedOfSpinner * Time.deltaTime);
    }
}
