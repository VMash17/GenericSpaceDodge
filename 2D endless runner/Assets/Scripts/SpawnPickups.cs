using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public GameObject shieldPickup;
    public float maxX, minX, maxY, minY;
    private float spawnTime, timeBetweenSpawn;

    void Start()
    {
        timeBetweenSpawn = Random.Range(10, 20);
    }

    void Update()
    {
        // Spawns pickups at random intervals
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
            timeBetweenSpawn = Random.Range(10, 20);
        }
    }

    // Spawns pickups at random locations
    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(shieldPickup, transform.position + new Vector3(x, y, 0), transform.rotation);
    }

    // Respawns to the start
    void Respawn(GameObject pickup)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        pickup.transform.position = new Vector3(x, y, 0);
    }

    // Hasn't been picked up so reapawn it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Respawn(collision.gameObject);
    }
}
