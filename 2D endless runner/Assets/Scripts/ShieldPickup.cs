using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pickupSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Moves to the left
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-1 * pickupSpeed, 0);
    }
}
