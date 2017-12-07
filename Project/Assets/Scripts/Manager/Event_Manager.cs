﻿using UnityEngine;

public class Event_Manager : MonoBehaviour {

    //Delegate to load in objects
    public delegate void LoadObjects();
    public static event LoadObjects LoadQuest;

    //Delegate to draw in objects
    public delegate void DrawObjects();
    public static event DrawObjects DrawQuests;

    //Delegate to add Quest to the QuestManager;
    public delegate void QuestData(Quest quest);
    public static event QuestData AddQuest;
    public static event QuestData AddQuestMarker;
    public static event QuestData AddQuestCircles;

    //Delegate to Toggle Objects
    public delegate void ToggleObjects(bool toggle, int name);
    public static event ToggleObjects ToggleDialog;

    //Set Quests in the quest manager
    public delegate void QuestListSet(System.Collections.Generic.List<Quest> ql);
    public static event QuestListSet SetQuestList;

    //Delegate to load in dialogs
    public delegate void Checks();
    public static event Checks DistanceCheck;

    public delegate void LoadDialog(string _name, string _description, System.Collections.Generic.List<Suspect> _suspects);
    public static event LoadDialog DialogLoad;
    //Loads in Objects in the scene and deletes other markers or data
    public static void Load_Objects(LOAD_OBJECTS lo) {
        switch (lo) {
            case LOAD_OBJECTS.Quest:
                LoadQuest();
                break;
            case LOAD_OBJECTS.Userdata:
                break;
        }
        LoadQuest();
    }
    public static void Add_Quest(Quest quest) {
        AddQuest(quest);
    }

    public static void Draw_Quest(DRAW_OBJECTS d_o) {
        switch (d_o) {
            case DRAW_OBJECTS.Quest:
                DrawQuests();
                break;
        }
    }
    public static void Toggle_Elements(DRAW_OBJECTS d_o, bool toggle, int id) {
        switch (d_o) {
            case DRAW_OBJECTS.Dialog:
                ToggleDialog(toggle, id);
                break;
        }
    }
    public static void Dialog_Load(string _name, string _description, System.Collections.Generic.List<Suspect> _suspects) {
        DialogLoad(_name, _description, _suspects);
    }
    public static void Add_QuestMarker(Quest quest) {
        AddQuestMarker(quest);
    }
    public static void Add_QuestCircles(Quest quest) {
        AddQuestCircles(quest);
    }
    public static void Distance_Check() {
        DistanceCheck();
    }
    public static void Set_QuestList(System.Collections.Generic.List<Quest> ql) {
        SetQuestList(ql);
    }
}
public enum LOAD_OBJECTS
{
    Quest,
    Userdata
}

public enum DRAW_OBJECTS {
    Quest,
    Userdata,
    Dialog
}