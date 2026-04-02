using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Transform target;

    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        
        if(Player != null)
        {
            target = Player.transform;
        }

    }

    void Update()
    {
        if (target != null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        Vector3 moveDir = direction.normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
        }
    }
}
