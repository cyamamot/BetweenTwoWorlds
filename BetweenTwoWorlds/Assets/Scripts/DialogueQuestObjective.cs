using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuestObjective : QuestObjective {

    [SerializeField]
    bool validObjective;

    void Awake() {
        enabled = false;
    }

    public override DialogueArray[] CheckObjective() {
        if (QuestManager.instance != null && QuestManager.instance.CheckQuestObjective(questKey.ToString(), questID, validObjective)) {
            return text;
        }
        return null;
    }
}
