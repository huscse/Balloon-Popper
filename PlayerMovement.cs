using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public bool isFacingRight { get; private set; } = true; 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(moveX, moveY) * moveSpeed;

        // update facing
        if (moveX > 0) isFacingRight = true;
        else if (moveX < 0) isFacingRight = false;

        // flip sprite visually
        if (sr) sr.flipX = !isFacingRight;
    }
}
