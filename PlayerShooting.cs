using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject pinPrefab;
    public Transform shootOrigin;
    public float shootSpeed = 12f;

    // choose ONE input path (either key OR axis button)
    public KeyCode fireKey = KeyCode.Space;
    // public string fireButton = "Fire1"; // alternative input method

    public float fireCooldown = 0.15f;   // debounce
    private float nextShootTime = 0f;

    PlayerMovement pm;

    void Awake() => pm = GetComponentInParent<PlayerMovement>();

    void Update()
    {
        bool pressed = Input.GetKeyDown(fireKey);                // <- single source of truth
        // bool pressed = Input.GetButtonDown(fireButton);       // <- alternative, but don't combine with the line above

        if (pressed && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + fireCooldown;
        }
    }

   void Shoot()
{
    if (!pinPrefab) { Debug.LogWarning("Pin prefab missing!"); return; }

    // spawn from origin (or player center)
    Vector3 spawnPos = shootOrigin ? shootOrigin.position : transform.position;

    // offset slightly in facing direction so it appears from the bow/hand
    float dir = (pm && pm.isFacingRight) ? 1f : -1f;
    spawnPos += new Vector3(0.4f * dir, 0.1f, 0f);

    var pin = Instantiate(pinPrefab, spawnPos, Quaternion.identity);

    // 1) horizontal velocity only (use Rigidbody2D.velocity)
    var rb = pin.GetComponent<Rigidbody2D>();
    if (rb) rb.linearVelocity = new Vector2(dir * shootSpeed, 0f);

    // 2) flip sprite **only by scale**, no rotation
    var s = pin.transform.localScale;
    s.x = Mathf.Abs(s.x) * (dir > 0 ? 1f : -1f);
    pin.transform.localScale = s;

    
}

}
