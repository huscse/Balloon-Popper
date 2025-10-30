using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinMovement : MonoBehaviour
{
    public float lifetime = 5f;
    public AudioClip popSound;
    public float fallbackDelay = 0.25f;   // used if no clip

    bool advancing;                       // guard so it runs once
    Rigidbody2D rb;
    Collider2D col;
    SpriteRenderer sr;

    void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr  = GetComponent<SpriteRenderer>();
    }

    void OnEnable() => Invoke(nameof(SelfDestruct), lifetime);
    void SelfDestruct() { if (!advancing) Destroy(gameObject); }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (advancing || !other.CompareTag("Balloon")) return;

        advancing = true;

        // pop feedback
        if (popSound) AudioSource.PlayClipAtPoint(popSound, transform.position, 1f);

        // scoring 
        if (ScoreManager.instance != null)
        {
            int points = Mathf.RoundToInt(100 / other.transform.localScale.x);
            ScoreManager.instance.AddScore(points);
        }

        Destroy(other.gameObject);   // pop balloon

        // freeze/vanish this pin so it can't hit anything else
        if (rb)  rb.simulated = false;
        if (col) col.enabled   = false;
        if (sr)  sr.enabled    = false;

        // wait for SFX, then advance
        float delay = popSound ? popSound.length : fallbackDelay;
        StartCoroutine(AdvanceAfterDelay(delay));
    }

    IEnumerator AdvanceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int cur  = SceneManager.GetActiveScene().buildIndex;
        int next = (cur + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(next);
    }
}
