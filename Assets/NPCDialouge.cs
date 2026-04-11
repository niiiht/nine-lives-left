using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialouge", menuName = "NPC Dialouge")]
public class NPCDialouge : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialougeLines;
    public bool[] autoProgressLines;
    public float autoProgerssDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
}
