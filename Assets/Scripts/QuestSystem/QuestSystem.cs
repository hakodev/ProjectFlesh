using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
public class QuestSystem : MonoBehaviour
{

    public UnityEvent<int> OnTaskCompleted;


    public List<QuestObjectUI> questUIObjects = new List<QuestObjectUI>();
    public List<QuestData> selectedQuests = new List<QuestData>();

    [SerializeField]
    private List<QuestData> allQuests = new List<QuestData>();


    public static QuestSystem instance;


    public QuestObjectUI objectUIPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
    }
   

    public void Initialize()
    {
        selectedQuests.Clear();
        selectedQuests = GetRandomQuest(3);

    }
    public List<QuestData> GetRandomQuest(int amount)
    {
        System.Random rnd = new System.Random();
        List<QuestData> datas = allQuests.OrderBy(x => rnd.Next()).ToList().Take(amount).ToList();
        List<QuestData> copyList = new List<QuestData>();
        foreach(QuestData q in datas)
        {
            copyList.Add(Instantiate(q));
        }
        return copyList;
    }


    public void CreateQuestObjects()
    {
        foreach(QuestObjectUI g in questUIObjects)
        {
            Destroy(g.gameObject);
        }
        questUIObjects.Clear();
        foreach(QuestData q in selectedQuests)
        {
            QuestObjectUI questObject= Instantiate(objectUIPrefab);
            questObject.Initialize(q);
            questUIObjects.Add(questObject);
        }
    }

    public void CheckQuestAction(int id)
    {
        int i = 0;
        foreach(QuestData q in selectedQuests)
        {
            if (!q.completed)
            {
                if (q.questID == id)
                {
                    q.Complete();
                    questUIObjects[i].Complete();
                }
            }
            i++;
        }

        foreach(QuestData q in selectedQuests)
        {
            if (q.completed == false) return;
        }

        AllQuestsCompleted();
    }

    public void AllQuestsCompleted()
    {
        //damn
    }



}


