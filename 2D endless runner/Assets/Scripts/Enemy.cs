using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemySpeed;
    public int maxCycles, cycles, max;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxCycles = Random.Range(4,9);
    }

    // Moves towards the left side
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-1 * enemySpeed, 0);
    }

    // Helps randomize the difficulty of the game
    // Once it reaches its max cycle, it will add to the max of the enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn" && cycles > maxCycles)
        {
            if (collision.gameObject.GetComponent<SpawnEnemy>().max < max)
            {
                collision.gameObject.GetComponent<SpawnEnemy>().max++;
            }
            
        }
        else if (collision.tag == "Respawn")
        {
            cycles++;
        }
    }
}
