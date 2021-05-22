using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Parameters Configuration


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
    #endregion

    #region Privte Members

    private float mShotCounter;

    #endregion
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

    #region Private Defined Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        var d = other.GetComponent<DamageDealer>();

        if (!d) return;

        Health -= d.GetDamage();

        d.Hit();

        if (Health <= 0) Die();
    }

    #endregion

    #region Private Methods

    private void Die()
    {
        Destroy(gameObject);

        FindObjectOfType<GameSession>().AddScore(Score);

        //Create the explosion effect and then destroy it.
        var ef=Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
        Destroy(ef,DurationOfExplosion);



        //Play the explosion sound
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position,EnemyExplosionVolume);

    }

    private void CountDownAndShot()
    {
        mShotCounter -= Time.deltaTime;
        if(mShotCounter <= 0)
        {
            Fire();
            mShotCounter = Random.Range(MinShotTime, MaxShotTime);
        }
    }

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
