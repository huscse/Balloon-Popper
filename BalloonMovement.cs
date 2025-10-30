using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = new Vector2(1f, 0.6f); // move diagonally (right + up)
    private SpriteRenderer sr;

    // camera edges
    private float leftEdge, rightEdge, topEdge, bottomEdge;
    public float padding = 0.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        direction = direction.normalized;

        var cam = Camera.main;
        float vertExtent = cam.orthographicSize;
        float horExtent = vertExtent * cam.aspect;
        Vector3 camPos = cam.transform.position;

        leftEdge = camPos.x - horExtent + padding;
        rightEdge = camPos.x + horExtent - padding;
        bottomEdge = camPos.y - vertExtent + padding;
        topEdge = camPos.y + vertExtent - padding;
    }

    void Update()
    {
        // Move
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        Vector3 pos = transform.position;

        // Horizontal bounce
        if (pos.x > rightEdge)
        {
            pos.x = rightEdge;
            direction.x = -Mathf.Abs(direction.x);
            sr.flipX = true;
        }
        else if (pos.x < leftEdge)
        {
            pos.x = leftEdge;
            direction.x = Mathf.Abs(direction.x);
            sr.flipX = false;
        }

        // Vertical bounce
        if (pos.y > topEdge)
        {
            pos.y = topEdge;
            direction.y = -Mathf.Abs(direction.y);
        }
        else if (pos.y < bottomEdge)
        {
            pos.y = bottomEdge;
            direction.y = Mathf.Abs(direction.y);
        }

        transform.position = pos;
    }
}
