using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Parameters Configuration

    [Header(header:"Gameplay")]
    [SerializeField] float Score = 100;
    [SerializeField] float Health=100;

    [Header(header:"Explosion")]
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] float DurationOfExplosion=0.75f;
    [Space]
    [SerializeField] AudioClip ExplosionSFX;
    [SerializeField] float EnemyExplosionVolume=0.5f;

    [Header(header:"Projectile")]
    [SerializeField] GameObject ProjectilePrefab;
    [Space]
    [SerializeField] float ProjectileVerticalSpeed = 1f;
    [SerializeField] float ProjectileHorizontalSpeed = 0f;
    [Space]
    [SerializeField] float MinShotTime = 0.2f;
    [SerializeField] float MaxShotTime = 3f;
    [Space]
    [SerializeField] AudioClip EnemyProjectileSFX;
    [SerializeField] float EnemyProjectileVolume = 0.25f;

    [Header(header:"PowerUps")]
    [SerializeField] int PowerDropProbability = 20;
    [SerializeField] int MaxNumOfPowerDrops = 1;
    #endregion

    #region Privte Members
    
    /// <summary>
    /// An temp int for shoting a projectile
    /// </summary>
    private float mShotCounter;

    #endregion

    #region Unity Defined Methods

    // Start is called before the first frame update
    void Start()
    {
        mShotCounter = Random.Range(MinShotTime, MaxShotTime);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }
    #endregion

    #region Private Defined Methods

    /// <summary>
    /// Calls when an object passes through the enemy
    /// </summary>
    /// <param name="other">The object (Collider)</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var d = other.GetComponent<DamageDealer>();
        HitProcess(d);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Make the best action when an object pass
    /// </summary>
    /// <param name="d">The damage of that object</param>
    private void HitProcess(DamageDealer d)
    {
        //Make sure that we have something to do
        if (!d) return;

        Health -= d.GetDamage();

        d.Hit();

        if (Health <= 0) Die();
    }

    /// <summary>
    /// Enemy Die process
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);

        FindObjectOfType<GameSession>().AddScore(Score);


        PowerDropProcess();

             //Create the explosion effect and then destroy it.
             var ef=Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
        Destroy(ef,DurationOfExplosion);



        //Play the explosion sound
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position,EnemyExplosionVolume);

    }

    /// <summary>
    /// Make a decision about dropping a  powerup 
    /// </summary>
    private void PowerDropProcess()
    {
       for(int i = 0; i <MaxNumOfPowerDrops; i++)
        {
            if (Random.Range(0, 100) < PowerDropProbability)
            {
                var power = FindObjectOfType<PowerUpGenerator>().SelectTheRightPower();

                //Make sure that we have something to do
                if (power != null) {
                    var pRandom = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f),transform.position.z);
                    Instantiate(power,transform.position + pRandom, Quaternion.identity);
                }
            }
        }
    }

    /// <summary>
    /// Start counting to shot
    /// </summary>
    private void CountDownAndShot()
    {
        mShotCounter -= Time.deltaTime;
        if(mShotCounter <= 0)
        {
            Fire();
            mShotCounter = Random.Range(MinShotTime, MaxShotTime);
        }
    }

    /// <summary>
    /// Calls when the enemy needs to shot
    /// </summary>
    private void Fire()
    {
        //Make an instant of fire
        var enemyLaser = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileHorizontalSpeed, -ProjectileVerticalSpeed);

        //Play the song
        AudioSource.PlayClipAtPoint(EnemyProjectileSFX, Camera.main.transform.position, EnemyProjectileVolume);
    }

    #endregion
}
