using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class CursorUniversal : MonoBehaviour
{
    public Texture2D normal;
    public Texture2D hover;
    public Texture2D click;

    private Texture2D current;

    void Start()
    {
        Cursor.visible = true;
        SetCursor(normal);
    }
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        bool overUI = IsPointerOverUI(mousePos);
        bool overWorld = IsPointerOverWorld(mousePos);

        if (overUI || overWorld)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                SetCursor(click);
            }
            else
            {
                SetCursor(hover);
            }
        }
        else
        {
            SetCursor(normal);
        }
    }

    bool IsPointerOverUI(Vector2 mousePos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = mousePos;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var r in results)
        {
            if (r.gameObject.CompareTag("click") || r.gameObject.CompareTag("item"))
                return true;
        }
        return false;
    }

    bool IsPointerOverWorld(Vector2 mousePos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z)
        );

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("click");
    }

    void SetCursor(Texture2D tex)
    {
        if (current == tex) return;
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
        current = tex;
    }
}