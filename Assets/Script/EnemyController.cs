using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private bool isVertical;
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem smokeEffect;
    [SerializeField] private AudioSource robot_Fixed;
    private int currentWayPointId = 0;
    private bool isFixed = false;
    Animator enmy_ani;
    Rigidbody2D enemy_rb;
    // Start is called before the first frame update
    void Start()
    {
        enmy_ani = GetComponent<Animator>();
        enemy_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed)
        {
            return;
        }

        if (Vector2.Distance(transform.position, wayPoints[currentWayPointId].transform.position) <.1f)
        {
            currentWayPointId++;
            if (currentWayPointId >= wayPoints.Length)
            {
                currentWayPointId = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointId].transform.position, speed * Time.deltaTime);
        if (isVertical)
        {
            enmy_ani.SetFloat("MoveX", 0);
            if (currentWayPointId == 0)
            {
                enmy_ani.SetFloat("MoveY", 1);
            }
            else
            {
                enmy_ani.SetFloat("MoveY", -1);
            }
        }
        else
        {
            enmy_ani.SetFloat("MoveY", 0);
            if (currentWayPointId == 0)
            {
                enmy_ani.SetFloat("MoveX", -1);
            } 
            else
            {
                enmy_ani.SetFloat("MoveX", 1);
            }
        }
    }

    public void Fix()
    {
        isFixed = true;
        enmy_ani.SetTrigger("Fixed");
        enemy_rb.simulated = false;
        smokeEffect.Stop();
        robot_Fixed.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator playerAni = collision.GetComponent<Animator>();
            if (playerAni != null)
            {
                playerAni.SetTrigger("Hit");
                if (PlayerHealth.Instance)
                {
                    PlayerHealth.Instance.TakeDame(damage);
                }
            }
        }
    }
}
