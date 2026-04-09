using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;
    public int currentHp;

    public GameObject xpPrefab;

    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("맞았음!");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (xpPrefab != null)
        {
            Instantiate(xpPrefab,transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
