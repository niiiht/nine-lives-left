using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public NPCDialouge dialougeData;
    private dialougeControl dialougeUI;

    public Sprite normalSprite;
    public Sprite highlightSprite;

    private int dialougeIndex;
    private bool acceptedQuest = false;
    private bool isTyping, isDialougeActive, isInRange;
    private SpriteRenderer sr;

    void Start()
    {
        dialougeUI = dialougeControl.Instance;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gracz"))
        {
            isInRange = true;
            sr.sprite = highlightSprite;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gracz"))
        {
            isInRange = false;
            sr.sprite = normalSprite;
        }
    }

    public bool CanInteract()
    {
        return isInRange && !isDialougeActive;
    }

    public void Interact()
    {
        if (!isInRange) return;
        if (dialougeData == null) return;

        if (isDialougeActive)
            NextLine();
        else
            StartDialouge();
    }

    void StartDialouge()
    {
        isDialougeActive = true;
        if (acceptedQuest)
        {
            dialougeIndex = 8;
        }
        else
        {
            dialougeIndex = 0;
        }

        dialougeUI.SetNPCInfo(dialougeData.npcName, dialougeData.npcPortrait);
        dialougeUI.ShowDialougeUI(true);

        DisplayCurrentLine();
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialougeUI.SetDialougeText(dialougeData.dialougeLines[dialougeIndex]);
            isTyping = false;
            return;
        }

        dialougeUI.ClearChoices();

        if (dialougeData.endDialougeLines.Length > dialougeIndex &&
            dialougeData.endDialougeLines[dialougeIndex])
        {
            EndDialouge();
            return;
        }

        if (TryShowChoices())
            return;

        if (++dialougeIndex < dialougeData.dialougeLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialouge();
        }
    }

    IEnumerator TypeLine()
    {
        if (dialougeIndex < 0 || dialougeIndex >= dialougeData.dialougeLines.Length)
        {
            EndDialouge();
            yield break;
        }
        isTyping = true;

        string currentLine = "";
        dialougeUI.SetDialougeText("");

        foreach (char letter in dialougeData.dialougeLines[dialougeIndex])
        {
            currentLine += letter;
            dialougeUI.SetDialougeText(currentLine);
            yield return new WaitForSeconds(dialougeData.typingSpeed);
        }

        isTyping = false;

        if (dialougeData.autoProgressLines.Length > dialougeIndex &&
            dialougeData.autoProgressLines[dialougeIndex])
        {
            yield return new WaitForSeconds(dialougeData.autoProgerssDelay);
            NextLine();
        }
    }

    bool TryShowChoices()
    {
        dialougeUI.ClearChoices();


        foreach (DialougeChoice choice in dialougeData.choices)
        {
            if (choice.dialougeIndex == dialougeIndex)
            {
                DisplayChoices(choice);
                return true;
            }
        }

        return false;
    }

    void DisplayChoices(DialougeChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialougeIndexes[i];
            dialougeUI.CreateChoiceButton(
                choice.choices[i],
                () => ChooseOption(nextIndex)
            );
        }
    }
    void ChooseOption(int nextIndex)
    {
        if (dialougeIndex < 0 || dialougeIndex >= dialougeData.dialougeLines.Length)
        {
            Debug.LogError("Z³y index dialogu: " + dialougeIndex);
            EndDialouge();
            return;
        }
        if (nextIndex == 7)
        {
            acceptedQuest = true;
        }

        dialougeUI.ClearChoices();
        dialougeIndex = nextIndex;
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    public void EndDialouge()
    {
        StopAllCoroutines();
        isDialougeActive = false;
        dialougeUI.SetDialougeText("");
        dialougeUI.ShowDialougeUI(false);
    }

    public bool IsDialogueActive()
    {
        return isDialougeActive;
    }
}

