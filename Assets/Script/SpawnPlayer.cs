using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer instance;

    public CharacterDatabase charDB;
    public CharacterInfo charInfo;
    public GameObject playerPos;
    public CinemachineVirtualCamera virtualCamera;

    private int selectId;
    private GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        selectId = PlayerPrefs.GetInt("SelectedOption");
        charInfo = charDB.GetCharInfo(selectId);
        playerPrefab = charInfo.character;
        SpawnChar();
    }

    private void SpawnChar()
    {
        GameObject playerObject = Instantiate(playerPrefab, playerPos.transform.position, Quaternion.identity);
        virtualCamera.Follow = playerObject.transform;
    }
}
