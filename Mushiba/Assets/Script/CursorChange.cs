using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D pushCursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(400,170), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(pushCursor, new Vector2(400, 170), CursorMode.ForceSoftware);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursor, new Vector2(400,170), CursorMode.ForceSoftware);
        }
    }
}
