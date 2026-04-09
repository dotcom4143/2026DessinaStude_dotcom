using Unity.VisualScripting;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackInterval = 1f;
    public float attackRange = 10f;
    public Transform FirePoint;

    private float attackTimer = 0f;
    private PlayerHealth playerHealth;


    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDistnace = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistnace && distance <= attackRange)
            {
                nearestDistnace = distance;
                nearest = enemy.transform;
            }
        }
        return nearest;
    }


    void Shoot(Transform target)
    {
        Vector3 direction = (transform.position - FirePoint.position).normalized;

        GameObject projectile = Instantiate(
            projectilePrefab,
            FirePoint.position,
            Quaternion.LookRotation(direction)
            );

        Projectile projectileScript = projectile.AddComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }
}
