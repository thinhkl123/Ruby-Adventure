using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public AudioSource playerHitSound;
    public AudioSource playerHealthSound;  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDame(float dame)
    {
        currentHealth -= dame;
        playerHitSound.Play();
        UpdateHealth();
    }

    public void Heal(float hp)
    {
        currentHealth += hp;
        playerHealthSound.Play();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        if (HealthBar.Instance != null)
        {
            HealthBar.Instance.SetHealthValue(currentHealth / maxHealth);
        }
    }
}
