using UnityEngine;

public class BounceTrigger : MonoBehaviour
{
    public float height = 0.5f;
    public float speed = 4f;

    private bool bouncing = false;
    private float t = 0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            bouncing = true;
            t = 0f;
        }

        if (bouncing)
        {
            t += Time.deltaTime * speed;

            float newY = startPos.y + Mathf.Sin(t * Mathf.PI) * height;
            transform.position = new Vector3(startPos.x, newY, startPos.z);

            if (t >= 1f)
            {
                bouncing = false;
                transform.position = startPos;
            }
        }
    }
}
