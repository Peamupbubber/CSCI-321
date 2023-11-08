using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D pointer;
    [SerializeField] private Texture2D target;
    [SerializeField] private Texture2D interact;
    [SerializeField] private Texture2D combat;
    [SerializeField] private LayerMask clickableLayer;

    // Update is called once per frame
    void Update()
    {
        CheckCursor();
    }

    private void CheckCursor() {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                Cursor.SetCursor(interact, Vector2.zero, CursorMode.Auto);
            }
            else if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Cursor.SetCursor(combat, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(target, Vector2.zero, CursorMode.Auto);
            }
        }
        else
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
    }
}
