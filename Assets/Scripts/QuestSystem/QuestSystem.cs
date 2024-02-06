using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{

    public UnityEvent<int> OnTaskCompleted;


    public List<QuestObjectUI> questUIObjects = new List<QuestObjectUI>();
    public List<QuestData> selectedQuests = new List<QuestData>();

    [SerializeField]
    private List<QuestData> allQuests = new List<QuestData>();


    public static QuestSystem instance;

    public GameObject questContent;
    public QuestObjectUI objectUIPrefab;
    public Sprite chaseTodo, normalTodo;
    public Image todoImage;
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


    private void Start()
    {
        HorrorSystem.instance.OnHorrorStart.AddListener(HorrorStart);
    }

    

    public void HorrorStart() {
        todoImage.sprite = chaseTodo;
    
    }

    public void DayBegin()
    {
        selectedQuests.Clear();
        selectedQuests = GetRandomQuest(3);
        todoImage.sprite = normalTodo;
        CreateQuestObjects();
    }
    public List<QuestData> GetRandomQuest(int amount)
    {
        System.Random rnd = new System.Random();
        List<QuestData> datas = allQuests.OrderBy(x => rnd.Next()).ToList().Take(amount).ToList();
        List<QuestData> copyList = new List<QuestData>();
        foreach (QuestData q in datas)
        {
            copyList.Add(Instantiate(q));
        }
        return copyList;
    }


    public void CreateQuestObjects()
    {
        foreach (QuestObjectUI g in questUIObjects)
        {
            Destroy(g.gameObject);
        }
        questUIObjects.Clear();
        foreach (QuestData q in selectedQuests)
        {
            QuestObjectUI questObject = Instantiate(objectUIPrefab,questContent.transform);
            questObject.Initialize(q);
            questUIObjects.Add(questObject);
        }
    }

    public void CheckQuestAction(int id)
    {
        int i = 0;
        foreach (QuestData q in selectedQuests)
        {
            if (!q.completed)
            {
                if (q.questID == id)
                {
                    q.Complete();
                    SanityManager.instance.SanityChange(q.sanityChange);
                    questUIObjects[i].Complete();
                }
            }
            i++;
        }

        foreach (QuestData q in selectedQuests)
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


