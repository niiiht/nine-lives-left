using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialouge", menuName = "NPC Dialouge")]
public class NPCDialouge : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialougeLines;
    public bool[] autoProgressLines;
    public bool[] endDialougeLines; //wybierz pozycje na której ma zakoñczyæ sie dialog w przypadku wyboru którjes z opcji
    public float autoProgerssDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

    public DialougeChoice[] choices;
}

[System.Serializable]

public class DialougeChoice
{
    public int dialougeIndex; // w której lini dialogu jest wybór
    public string[] choices; // opcje wyboru
    public int[] nextDialougeIndexes; //co sie dzieje po wyborze
}