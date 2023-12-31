using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;
    private VisualElement m_charPortrait;
    private VisualElement m_HealthBar;
    private VisualElement m_NPCDialogue;
    private VisualElement m_NPCDialogue_1;

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
        UIDocument uIDocument = GetComponent<UIDocument>();
        m_charPortrait = uIDocument.rootVisualElement.Q<VisualElement>("CharacterPortrait");
        m_HealthBar = uIDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        m_NPCDialogue = uIDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NPCDialogue_1 = uIDocument.rootVisualElement.Q<VisualElement>("NPCDialogue 1");
        m_charPortrait.style.backgroundImage = new StyleBackground(SpawnPlayer.instance.charInfo.portrait);
        m_NPCDialogue.style.display = DisplayStyle.None;
        m_NPCDialogue_1.style.display = DisplayStyle.None;
        SetHealthValue(1.0f);
    }

    public void SetHealthValue(float per)
    {
        if (per > 1)
        {
            per = 1;
        }
        m_HealthBar.style.width = Length.Percent(100 * per);
    }

    public void OpenNPCDialogueUI()
    {
        m_NPCDialogue.style.display = DisplayStyle.Flex;
    }

    public void CloseNPCDialogueUI()
    {
        m_NPCDialogue.style.display = DisplayStyle.None;
    }

    public void OpenNPCDialogueUI_1()
    {
        m_NPCDialogue.style.display = DisplayStyle.Flex;
    }

    public void CloseNPCDialogueUI_1()
    {
        m_NPCDialogue.style.display = DisplayStyle.None;
    }
}
