using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Parameters Configuration
    [Header(header:"Player GamePlay")]
    [SerializeField] float Health = 200;
    [Space]
    /// <summary>
    /// The speed of the player
    /// </summary>
    [SerializeField] float PlayerSpeed = 15f;

    /// <summary>
    /// The movement padding
    /// </summary>
    [SerializeField] float MovementPadding = 0.5f;
    [Space]

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


    [Header(header:"Explosions")]
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

    /// <summary>
    /// The coroutine which player firing run on it.
    /// </summary>
    private Coroutine mFiringCoroutine;


    private GameObject mShield;
    #endregion

    #region Default Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        mGameCamera = Camera.main;
        SetUpMovementBoundries();
        PlayerProjectile.GetComponent<DamageDealer>().InitialDamage= PlayerProjectile.GetComponent<DamageDealer>().GetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Fire();
        SetUpShieldPosition();
    }

    #endregion

    #region Private Defined Methods

    /// <summary>
    /// Calls when the collision occurs
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {

        var d = other.GetComponent<DamageDealer>();
        HitProcess(d);
    }

    #endregion

    #region Private Helpers Methods

    /// <summary>
    /// Calls to make a decision about the hit
    /// </summary>
    /// <param name="d"></param>
    private void HitProcess(DamageDealer d)
    {
        if (!d || Shield) return;

        Health -= d.GetDamage();
        d.Hit();

        if (Health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);

        //Play the explosion song
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position, PlayerExplosionVolume);

        PlayerProjectile.GetComponent<DamageDealer>().ResetDamge();

        FindObjectOfType<Level>().LoadGameOver();
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


    private void SetUpShieldPosition()
    {
        if (Shield)StartCoroutine(MoveShieldWithPlayer());
    }
    private IEnumerator MoveShieldWithPlayer()
    {
        if (mShield != null) Destroy(mShield);

        mShield = Instantiate(ShieldPrefab, transform.position, Quaternion.identity);
            mShield.transform.position = transform.position;
        yield return new WaitForSeconds(DurationOfShield);
        Shield = false;
        Destroy(mShield);

    }
    #endregion

    #region Public Methods

    /// <summary>
    /// Increase the player health
    /// </summary>
    /// <param name="health"></param>
    /// <returns></returns>
    public void AddHealth(float health) => Health += health;

    /// <summary>
    /// The current health of the player
    /// </summary>
    /// <returns></returns>
    public float GetHealth() => Health;


    
    /// <summary>
    /// Icnrease the damage of the projectile
    /// </summary>
    /// <param name="incrementFactor"></param>
    public void IncreaseProjectileDamage(float incrementFactor)=>
        PlayerProjectile.GetComponent<DamageDealer>().AddDamage(incrementFactor);
    #endregion

    #region Public Properties
    /// <summary>
    /// Is the player protecting by the shield
    /// </summary>
    public bool Shield { set; private get; } = false;

    /// <summary>
    /// The prefab for the shield
    /// </summary>
    public GameObject ShieldPrefab { set; private get; }

    /// <summary>
    /// The duration of shiled
    /// </summary>
    public float DurationOfShield { set; private get; }
    #endregion
}
