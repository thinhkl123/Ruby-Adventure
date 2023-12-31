using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue_1_Controller : MonoBehaviour
{
    public AudioSource completedSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HealthBar.Instance)
            {
                HealthBar.Instance.OpenNPCDialogueUI_1();
                completedSound.Play();
                Time.timeScale = 0;
            }
        }
    }
}
