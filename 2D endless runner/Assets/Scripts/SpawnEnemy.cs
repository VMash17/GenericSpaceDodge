using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float maxX, minX, maxY, minY, timeBetweenSpawn;
    public int max;
    private float spawnTime;
    private int count = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Spawns enemies at intervals if max isn't reached
        if (Time.time > spawnTime && count < max)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
            count++;
        }
    }

    // Spawns enemies at random locations
    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(enemy, transform.position + new Vector3(x, y, 0), transform.rotation);
    }

    // Respawns the enemy to the start
    void Respawn(GameObject enemy)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        enemy.transform.position = new Vector3(x, y, 0);
    }

    // When the enemy reaches the end, respawn them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Respawn(collision.gameObject);
    }
}
