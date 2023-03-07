using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject platformThree;
    public float eTimer = 0f;
    public float pTimer = 0f;
    public float eSpawnRate;
    public float pSpawnRate;
    float sideVariance = -23;
    //int wave = 1;
    public GameManager gameManager;
    bool ready = false;
    int toSpawn = 0;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawn();

    }

    // Update is called once per frame
    void Update()
    {
        eTimer += Time.deltaTime;
        if (eTimer >= eSpawnRate)
        {
            eTimer = 0;
            ready = true;
        }

        if (gameManager.waveStart && ready)
        {
            if (toSpawn < gameManager.enemiesToKill)
            {
                enemySpawn();
                toSpawn++;
            }
            else
            toSpawn = 0;
            ready = false;
        }

        if (gameManager.BossTime)
        {
           gameManager.finale = true;
            gameManager.BossTime = false;
            bossSpawn();
        }

        pTimer += Time.deltaTime;
        if (pTimer >= pSpawnRate)
        {
            platformSpawn();
            pTimer = 0;
        }

    }

    public void platformSpawn()
    {
        float spawnV = Random.Range(1, 4);
        sideVariance = Random.Range(-26, 26);

        switch (spawnV)
        {
            case 1: Instantiate(platformOne, new Vector3(sideVariance, transform.position.y, transform.position.z), transform.rotation); break;
            case 2: Instantiate(platformTwo, new Vector3(sideVariance, transform.position.y, transform.position.z), transform.rotation); break;
            case 3: Instantiate(platformThree, new Vector3(sideVariance, transform.position.y, transform.position.z), transform.rotation); break;
        }
    }

    public void enemySpawn()
    {
        //Debug.Log("Hello");
        float spawnV = Random.Range(1, 4);
        //float sideVariance = Random.Range(-22, 22);
        switch (spawnV)
        {
            case 1: Instantiate(enemyOne, new Vector3(sideVariance, transform.position.y + 2, transform.position.z), transform.rotation); break;
            case 2: Instantiate(enemyTwo, new Vector3(sideVariance, transform.position.y + 2, transform.position.z), transform.rotation); break;
            case 3: Instantiate(enemyThree, new Vector3(sideVariance, transform.position.y + 2, transform.position.z), transform.rotation); break;
        }
    }

    public void bossSpawn()
    {
        //sideVariance = Random.Range(-18, 18);

        Instantiate(boss, new Vector3(sideVariance, transform.position.y + 2, transform.position.z), transform.rotation);
    }
}
