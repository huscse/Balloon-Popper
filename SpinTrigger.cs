using UnityEngine;

public class SpinTrigger : MonoBehaviour
{
    public float speed = 360f;
    public float duration = 1f;

    private bool spinning = false;
    private float timer = 0f;

    void Update()
    {
        // When player presses F, animation starts
        if (Input.GetKeyDown(KeyCode.F))
        {
            spinning = true;
            timer = duration; 
        }

        if (spinning)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);

            timer -= Time.deltaTime;
            if (timer <= 0)
                spinning = false; // animation stops
        }
    }
}
