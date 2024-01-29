using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestObjectUI : MonoBehaviour
{
    QuestData quest;
    public Image questCompletedChecker;
    public TextMeshProUGUI questDescriptionDisplay;
    public void Initialize(QuestData questData)
    {
        quest = questData;
        questDescriptionDisplay.text = quest.questDescription;

    }

    public void Complete()
    {
        questCompletedChecker.gameObject.SetActive(true);
    }



}
