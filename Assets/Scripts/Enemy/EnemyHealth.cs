using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    public GameObject AmmoLootPrefab;
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    GameObject _ammoLootTracker;
    private GameObject alterEgo;
    public GameObject alterEgoPrefab;


    public PlayerHealth playerHealth;
    public static int deathCount;

    void Start()
    {
        _ammoLootTracker = GameObject.FindGameObjectWithTag("AmmoLootTracker");
    }

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        playerHealth = GetComponent<PlayerHealth>();
        currentHealth = startingHealth;
    }

    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        // Trigger floating text
        if (FloatingTextPrefab && currentHealth > 0)
        {
            ShowEnemyText();
        }
        ShowEnemyText();

        if(currentHealth <= 0)
        {
            Death ();
            deathCount++;
           
            // playerHealth.currentHealth += 2;
        }
    }

    void ShowEnemyText() 
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = currentHealth.ToString();

    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();

        for(int i = 0; i < startingHealth / 10; i++) 
        {
            var obj = Instantiate(AmmoLootPrefab, transform.position + new Vector3(0, Random.Range(0,2)), Quaternion.identity);
            obj.GetComponent<Follow>().Target = _ammoLootTracker.transform;
        }

        // Debug.Log(weapon.showCurrentAmmo);
        
        // weapon.currentAmmo += AmmoLoot;
        // Debug.Log(weapon.currentAmmo);


    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        KillManager.death += 1;
        // Debug.Log("Death to " + gameObject.name);
        if (alterEgo) Destroy(alterEgo);
        Destroy (gameObject, 2f);
    }

    public void Convert () // convert to alter Ego
    {
        if (alterEgo == null)
        {
            if (alterEgoPrefab == null) return; // I cannot be converted
            alterEgo = Instantiate(alterEgoPrefab, transform.position, transform.rotation);
            alterEgo.GetComponent<EnemyHealth>().alterEgo = gameObject;
            // Debug.Log("Created alter Ego for " + gameObject.name);
        }
        alterEgo.transform.SetPositionAndRotation(transform.position, transform.rotation);
        gameObject.SetActive(false);
        alterEgo.SetActive(true);
    }

}
