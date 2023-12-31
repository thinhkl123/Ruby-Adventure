using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject speechIcon;
    private bool isTalking;

    private void Start()
    {
        isTalking = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && isTalking) 
        {
            if (HealthBar.Instance)
            {
                HealthBar.Instance.OpenNPCDialogueUI();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speechIcon.SetActive(true);
            isTalking=true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speechIcon.SetActive(false);
            isTalking=false;
            if (HealthBar.Instance)
            {
                HealthBar.Instance.CloseNPCDialogueUI();
            }
        }
    }
}
