 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectManager : MonoBehaviour
{
    public CharacterDatabase charDB;
    public Image charSprite;

    private int selectId = 0;

    private void Start()
    {
        UpdateSelectOption(selectId);
        Save();
    }

    public void NextOption()
    {
        selectId++;
        if (selectId >= charDB.charCount)
        {
            selectId = 0;
        }
        UpdateSelectOption(selectId);
        Save();
    }

    public void BackOption()
    {
        selectId--;
        if (selectId < 0)
        {
            selectId = charDB.charCount;
        }
        UpdateSelectOption(selectId);
        Save();
    }

    private void UpdateSelectOption(int selectId)
    {
        CharacterInfo charInfo = charDB.GetCharInfo(selectId);
        charSprite.sprite = charInfo.charSprite;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", selectId);
    }
}
