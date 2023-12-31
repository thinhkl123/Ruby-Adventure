using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float hitTime;
    Animator playerAni;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAni = collision.GetComponent<Animator>();
            if (playerAni != null)
            {
                InvokeRepeating("PlayHitAni", 0f, hitTime);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("PlayHitAni");
    }
    private void PlayHitAni()
    {
        playerAni.SetTrigger("Hit");
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.TakeDame(damage);
        }
    }
}
