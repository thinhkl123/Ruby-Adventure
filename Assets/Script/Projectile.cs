using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D ptile_rb;
    // Start is called before the first frame update
    void Awake()
    {
        ptile_rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float speed)
    {
        ptile_rb.AddForce(direction*speed, ForceMode2D.Impulse);
        Debug.Log(direction + ", " + speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Fix();
            }
            Destroy(gameObject);
        }
    }
}
