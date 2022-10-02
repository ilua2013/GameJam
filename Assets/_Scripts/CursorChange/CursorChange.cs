using UnityEngine;

public class CursorChange : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorNormal;
    [SerializeField] private Texture2D _cursorAttack;
    [SerializeField] private Texture2D _cursorItems;
    [SerializeField] private int _sizeCursor = 32;

    private Vector2 _offset;
    private Texture2D _cursor;

    void Awake()
    {
        Cursor.visible = false;
    }

    void MainCursor(string tags)
    {
        if (tags == "Enemy")
        {
            _offset = Vector2.zero;
            _cursor = _cursorAttack;
        }
        else if (tags == "Items")
        {
            _offset = Vector2.zero;
            _cursor = _cursorItems;
        }
        else
        {
            _offset = Vector2.zero;
            _cursor = _cursorNormal;
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layermask = 1;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask, QueryTriggerInteraction.Ignore))
        {
            MainCursor(hit.transform.tag);
        }
        else
        {
            _offset = Vector2.zero;
            _cursor = _cursorNormal;
        }
    }

    void OnGUI()
    {
        Vector2 mousePos = Event.current.mousePosition;
        GUI.depth = 999;
        GUI.Label(new Rect(mousePos.x + _offset.x, mousePos.y + _offset.y, _sizeCursor, _sizeCursor), _cursor);
    }
}
