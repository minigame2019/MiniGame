using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Quest Quest;

    public Text TextQuest;

    public Text TextTasks;

    public GameObject TasksUI;

    public String No_Quest_Text = "- No Quest accepted -";

    public void Start()
    {

        SetQuest(Quest);

    }

    public void QuestSolved(Quest quest)
    {
        TextQuest.text = Quest.Name + " solved!";
        TasksUI.SetActive(false);
        Invoke("ClearQuest", 3);
    }

    public void ClearQuest()
    {
        SetQuest(null);
    }

    public void SetQuest(Quest quest)
    {
        int height = 70;

        if(quest!= null)
        {
            Quest = quest;
            TextQuest.text = Quest.Name;

            TasksUI.SetActive(true);

            foreach(QuestTask task in quest.Tasks)
            {
                TextTasks.text += task.Name + Environment.NewLine;
                height += 20;
            }

            var rect_task_UI = TasksUI.GetComponent<RectTransform>();
            rect_task_UI.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
        else
        {
            TasksUI.SetActive(false);
            TextTasks.text = "";
            TextQuest.text = No_Quest_Text;
        }
    }
}
