using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public NPCDialouge dialougeData;
    public GameObject dialougePanel;
    public TMP_Text dialougeText, nameText;
    public Image portraitImage;
    public Sprite normalSprite;
    public Sprite highlightSprite;

    private int dialougeIndex;
    private bool isTyping, isDialougeActive, isInRange;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gracz"))
            isInRange = true;
            sr.sprite = highlightSprite;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gracz"))
            isInRange = false;
            sr.sprite = normalSprite;
    }
    public bool CanInteract()
    {
        return isInRange && !isDialougeActive;
    }
    public void Interact()
    {
        if (!isInRange) 
            return;
        if (dialougeData == null/* || (PauseController.IsGamePaused && !isDialougeActive (nie mamy pauzyzaimplementowanej))*/)
            return;
        if (isDialougeActive)
        {
            NextLine();
        }
        else
        {
            StartDialouge();
        }
    }
    void StartDialouge()
    {
        isDialougeActive = true;
        dialougeIndex = 0;

        nameText.SetText(dialougeData.npcName);
        portraitImage.sprite = dialougeData.npcPortrait;

        dialougePanel.SetActive(true);
        //PauseController.SetPause(true);

        StartCoroutine(TypeLine());

    }
    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialougeText.SetText(dialougeData.dialougeLines[dialougeIndex]);
            isTyping = false;
        }
        else if (++dialougeIndex < dialougeData.dialougeLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialouge();
        }
    }
            IEnumerator TypeLine()
            {
                isTyping = true;
                dialougeText.SetText("");

                foreach (char letter in dialougeData.dialougeLines[dialougeIndex])
                {
                    dialougeText.text += letter;
                    yield return new WaitForSeconds(dialougeData.typingSpeed);
                }
                isTyping = false;
                if (dialougeData.autoProgressLines.Length > dialougeIndex && dialougeData.autoProgressLines[dialougeIndex])
                {
                    yield return new WaitForSeconds(dialougeData.autoProgerssDelay);
                    NextLine();
                }
            }
    public void EndDialouge()
    {
        StopAllCoroutines();
        isDialougeActive = false;
        dialougeText.SetText("");
        dialougePanel.SetActive(false);
        //PauseController.SetPause(false);
    }
}

