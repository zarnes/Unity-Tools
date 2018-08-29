using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsFinder2D : MonoBehaviour
{
    public Vector2 TopLeft = Vector2.zero;
    public Vector2 TopRight = Vector2.zero;
    public Vector2 BottomLeft = Vector2.zero;
    public Vector2 BottomRight = Vector2.zero;

    public Camera Camera;
    public bool DrawGizmos;

    public bool ManualUpdate;
    public float UpdateDelay = 1f;
    private float _nextUpdate;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextUpdate)
            GetBounds();
    }

    public void GetBounds()
    {
        _nextUpdate = Time.time + UpdateDelay;

        if (Camera == null || !Camera.orthographic)
            return;

        float horizontalSize = Camera.orthographicSize * Screen.width / Screen.height;
        float verticalSize = Camera.orthographicSize;

        Vector2 camPos = Camera.transform.position;
        TopLeft = new Vector2(camPos.x - horizontalSize, camPos.y + verticalSize);
        TopRight = new Vector2(camPos.x + horizontalSize, camPos.y + verticalSize);
        BottomLeft = new Vector2(camPos.x - horizontalSize, camPos.y - verticalSize);
        BottomRight = new Vector2(camPos.x + horizontalSize, camPos.y - verticalSize);
    }

    private void OnDrawGizmos()
    {
        if (DrawGizmos)
        {
            float lineLength = Camera.orthographicSize / 10;

            Gizmos.DrawLine(TopLeft + new Vector2(-lineLength, 0), TopLeft + new Vector2(lineLength, 0));
            Gizmos.DrawLine(TopLeft + new Vector2(0, -lineLength), TopLeft + new Vector2(0, lineLength));

            Gizmos.DrawLine(TopRight + new Vector2(-lineLength, 0), TopRight + new Vector2(lineLength, 0));
            Gizmos.DrawLine(TopRight + new Vector2(0, -lineLength), TopRight + new Vector2(0, lineLength));

            Gizmos.DrawLine(BottomLeft + new Vector2(-lineLength, 0), BottomLeft + new Vector2(lineLength, 0));
            Gizmos.DrawLine(BottomLeft + new Vector2(0, -lineLength), BottomLeft + new Vector2(0, lineLength));

            Gizmos.DrawLine(BottomRight + new Vector2(-lineLength, 0), BottomRight + new Vector2(lineLength, 0));
            Gizmos.DrawLine(BottomRight + new Vector2(0, -lineLength), BottomRight + new Vector2(0, lineLength));
        }
    }
}