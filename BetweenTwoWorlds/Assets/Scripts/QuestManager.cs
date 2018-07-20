using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;

    public enum QuestLineID {
        MainQuestID,
        SideQuest1ID,
        SideQuest2ID,
    };

    void Awake() {
        enabled = false;
        if (instance == null) {
            instance = this;
            ZPlayerPrefs.Initialize("yamamoto", "A11356495");
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    public bool CheckQuestObjective(string key, int id, bool validObjective) {
        if (id == ZPlayerPrefs.GetInt(key, 0)) {
            if (validObjective) {
                ZPlayerPrefs.SetInt(key, id += 1);
                ZPlayerPrefs.Save();
            }
            return true;
        }
        return false;
    }
}
