using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hitForce;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioSource playerRunSound;
    [SerializeField] private AudioSource playerThrowSound;
    public float speedGun;
    private float tiimeBtwPlayThorw = 0.5f;
    public float timeAccess;
    public Vector2 moveInput, input;

    Rigidbody2D m_rb;
    Animator m_ani;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_ani = GetComponent<Animator>();
        input = new Vector2(1, 0);
        transform.localScale = new Vector3(-1, 1, 0);
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeAccess += Time.deltaTime;
        moveInput.x = Input.GetAxis("Horizontal");
        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            } 
            else
            {
                transform.localScale = new Vector3(-1,1,0);
            }
        }
        moveInput.y = Input.GetAxis("Vertical");
        if (moveInput != Vector2.zero)
        {
            input = moveInput;
        }
        m_ani.SetFloat("Speed", moveInput.magnitude);
        if (moveInput.magnitude > 0 && timeAccess >= tiimeBtwPlayThorw)
        {
            playerRunSound.Play();
            timeAccess = 0;
        }
        m_ani.SetFloat("MoveX", input.x);
        m_ani.SetFloat("MoveY", input.y);

        //Launch
        if (Input.GetMouseButtonDown(0))
        {
            m_ani.SetTrigger("Launch");
            Launch();
        }
    }
    void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void Launch()
    {
        GameObject projectileObject =  Instantiate(projectilePrefab, m_rb.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        Vector2 direction = input;
        if (direction.x != 0)
        {
            if (direction.x > 0)
                direction.x = 1;
            else
                direction.x = -1;
        }
        if (direction.y != 0)
        {
            if (direction.y > 0)
                direction.y = 1;
            else
                direction.y = -1;
        }
        if (projectile != null)
        {
            projectile.Launch(direction, speedGun);
        }
        playerThrowSound.Play();
    }
}
