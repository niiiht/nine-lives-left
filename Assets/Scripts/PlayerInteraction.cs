using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private NPC activeNPC;
    void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        if (activeNPC != null)
        {
            activeNPC.Interact();
            return;
        }
        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z)
        );

        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        if (hit != null)
        {
            NPC npc = hit.GetComponent<NPC>();

            if (npc != null && npc.CanInteract())
            {
                activeNPC = npc;
                npc.Interact();
            }
        }
    }
    public void ClearActiveNPC()
    {
        activeNPC = null;
    }
}
