using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestObjective : MonoBehaviour {

    [SerializeField]
    protected QuestManager.QuestLineID questKey;
    [SerializeField]
    protected int questID;
    [SerializeField]
    protected DialogueArray[] text;

    public abstract DialogueArray[] CheckObjective();
}
