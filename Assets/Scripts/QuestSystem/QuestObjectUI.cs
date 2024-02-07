using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

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
        questCompletedChecker.transform.localScale = Vector3.zero;
        questCompletedChecker.transform.DOScale(Vector3.one, 0.5f);
    }



}
