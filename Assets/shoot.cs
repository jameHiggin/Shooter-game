using UnityEngine;

public class CubeShooter : MonoBehaviour
{
    public GameObject projectilePrefab;  // The sphere to shoot
    public Transform player;             // Reference to the player (capsule)
    public float shootForce = 20f;       // Force with which the sphere is shot
    public float shootInterval = 2f;     // Time between each shot
    public float projectileLifetime = 5f; // How long before the projectile disappears

    private float shootTimer;            // Timer to control shooting intervals

    void Update()
    {
        // Make the cube face the player
        Vector3 directionToPlayer = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Shoot at intervals
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        // Instantiate the sphere in front of the cube
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, Quaternion.identity);

        // Apply force to the projectile to shoot it
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);

        // Destroy the projectile after a few seconds
        Destroy(projectile, projectileLifetime);
    }
}