using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public float waveAmplitude = 0.4f;
    public float waveFrequency = 2.0f;

    private int dir = 1; // 1 = right, -1 = left
    private float baseY;

    void Start()
    {
        baseY = transform.position.y;
        // Randomize starting direction a bit
        if (Random.value < 0.5f) dir = -1;
    }

    void Update()
    {
        // horizontal + wavy vertical motion
        float y = baseY + Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        transform.position += new Vector3(dir * speed, 0f, 0f) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, 0f);

        // bounce at screen edges (viewport 0..1)
        var v = Camera.main.WorldToViewportPoint(transform.position);
        if (v.x < 0.05f || v.x > 0.95f) dir *= -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If a pin hits a bird, delete the pin (no score)
        if (other.gameObject.name.Contains("Arrow") || other.CompareTag("Pin"))
        {
            Destroy(other.gameObject);
        }
    }
}
