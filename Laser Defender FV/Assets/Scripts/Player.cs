using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Parameters Configuration

    /// <summary>
    /// The speed of the player
    /// </summary>
    [SerializeField] float PlayerSpeed = 15f;

    /// <summary>
    /// The movement padding
    /// </summary>
    [SerializeField] float MovementPadding=0.5f;

    /// <summary>
    /// The speed of player projectile(Laser)
    /// </summary>
    [SerializeField] float ProjectileSpeed = 10f;

    /// <summary>
    /// The speed of player projectile(Laser)
    /// </summary>
    [SerializeField] float DurationOfProjectileSpawn = 0.1f;

    /// <summary>
    /// The associated laser sprite of the player.
    /// </summary>
    [SerializeField] GameObject PlayerProjectile;

    [Header(header:"Player GamePlay")]
    [SerializeField] float Health = 200;
    [Space]
    [SerializeField] AudioClip ExplosionSFX;
    [SerializeField] float PlayerExplosionVolume=0.75f;
    #endregion

    #region Private Members

    /// <summary>
    /// The main game camera
    /// </summary>
    private Camera mGameCamera;

    /// <summary>
    /// The possible max and min positions
    /// </summary>
    private float mMaxX, mMaxY, mMinX, mMinY;

    private Coroutine mFiringCoroutine;

    #endregion

    #region Default Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        mGameCamera = Camera.main;
        SetUpMovementBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Fire();

    }

    #endregion

    #region Private Defined Methods
    private void OnTriggerEnter2D(Collider2D other)
    {

        var d = other.GetComponent<DamageDealer>();
        if (!d) return;

        Health -= d.GetDamage();

        if (Health <= 0) Die();
    }

    #endregion

    #region Private Helpers Methods
    private void Die()
    {
        Destroy(gameObject);

        //Play the explosion song
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position, PlayerExplosionVolume);
    }

    /// <summary>
    /// Start Firing
    /// </summary>
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")) mFiringCoroutine= StartCoroutine(FiringContinously());
        if(Input.GetButtonUp("Fire1")) StopCoroutine(mFiringCoroutine);
    }
    private IEnumerator FiringContinously()
    {
        while (true)
        {
            var projectile = Instantiate(PlayerProjectile, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ProjectileSpeed);
            yield return new WaitForSeconds(DurationOfProjectileSpawn);
        }
    }

    /// <summary>
    /// Set up the max and min possible position for moving the player
    /// </summary>
    private void SetUpMovementBoundries()
    {
        mMaxX = mGameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - MovementPadding;
        mMinX = mGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + MovementPadding;

        mMaxY = mGameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - MovementPadding;
        mMinY = mGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + MovementPadding;
    }

    /// <summary>
    /// Moves the player based on the input keys.
    /// </summary>
    private void PlayerMovement()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var newXPos = horizontalMovement * Time.deltaTime * PlayerSpeed;
        var newYPos = verticalMovement * Time.deltaTime * PlayerSpeed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + newXPos, mMinX, mMaxX),
            Mathf.Clamp(transform.position.y + newYPos, mMinY, mMaxY),transform.position.z);
    }

    #endregion
}
