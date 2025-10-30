using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonGrowth : MonoBehaviour
{
    public float sizeStep = 0.05f;     // how much it grows each tick
    public float interval = 1.0f;      // seconds between growth
    public float maxScale = 1.6f;      // the “too big” threshold (tune)

    void Start()
    {
        InvokeRepeating(nameof(Grow), interval, interval);
    }

    void Grow()
    {
        transform.localScale += Vector3.one * sizeStep;

        if (transform.localScale.x >= maxScale)
        {
            // balloon gets too big → no points → restart current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
