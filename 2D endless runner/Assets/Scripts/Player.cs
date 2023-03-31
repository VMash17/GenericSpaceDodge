using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameManager;
    private AudioSource shieldClip;
    private Rigidbody2D rb;
    private SpriteRenderer shieldImage;
    private Vector2 playerDirection;
    public float playerSpeed;
    private int shields;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shieldImage = GetComponent<SpriteRenderer>();
        shieldClip = GetComponent<AudioSource>();
    }

    // Gets direction if you press up or down key
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection  = new Vector2(0, directionY).normalized;
    }

    // Moves the player in the direction and duration pressed
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    // Game over when you touch the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            shieldClip.Play();
            shields++;
            shieldImage.enabled = true;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            if (shields > 0)
            {
                shields--;
                
                if (shields == 0)
                {
                    shieldImage.enabled = false;
                }
            }
            else
            {
                gameOver.SetActive(true);
                gameManager.GetComponent<ScoreManager>().gameOver = true;
                Destroy(this.gameObject);
            }
        }
    }
}
