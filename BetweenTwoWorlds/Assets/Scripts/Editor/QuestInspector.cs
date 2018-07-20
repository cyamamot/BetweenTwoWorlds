using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestInspector : EditorWindow {

    QuestManager manager;
    int MainQuestID;
    int SideQuest1ID;
    int SideQuest2ID;
    string resetKey;

    [MenuItem("Window/Quest Inspector")]
    static void Init() {
        QuestInspector qi = (QuestInspector)EditorWindow.GetWindow(typeof(QuestInspector));
        qi.Show();
    }

    public void OnInspectorUpdate() {
        Repaint();
    }

    void OnGUI() {
        manager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
        GUILayout.BeginHorizontal();
        GUI.color = Color.white;
        GUILayout.BeginVertical("Box");
        MainQuestID = EditorGUILayout.IntField("MainQuestID", MainQuestID);
        SideQuest1ID = EditorGUILayout.IntField("SideQuest1ID", SideQuest1ID);
        SideQuest2ID = EditorGUILayout.IntField("SideQuest2ID", SideQuest2ID);
        EditorGUILayout.Space();
        resetKey = GUILayout.TextField(resetKey, GUILayout.Width(Screen.width - 10.0f), GUILayout.Height(15.0f));
        if (GUILayout.Button("RESET QUESTLINES", GUILayout.Width(Screen.width - 10.0f), GUILayout.Height(50.0f))) {
            OnResetPress();
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        SetQuestInspector();
    }

    void SetQuestInspector() {
        MainQuestID = ZPlayerPrefs.GetInt("MainQuestID", 0);
        SideQuest1ID = ZPlayerPrefs.GetInt("SideQuest1ID", 0);
        SideQuest2ID = ZPlayerPrefs.GetInt("SideQuest2ID", 0);
    }

    void OnResetPress() {
        if (resetKey == "RESET QUESTLINES") {
            ZPlayerPrefs.SetInt("MainQuestID", 0);
            ZPlayerPrefs.SetInt("SideQuest1ID", 0);
            ZPlayerPrefs.SetInt("SideQuest2ID", 0);
            ZPlayerPrefs.Save();
            resetKey = "";
        }
    }
}

