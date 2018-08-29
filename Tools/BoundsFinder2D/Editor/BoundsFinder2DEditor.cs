using UnityEngine;
using UnityEditor;
using Debug = System.Diagnostics.Debug;

[CustomEditor(typeof(BoundsFinder2D))]
public class BoundsFinder2DEditor : Editor
{
    private BoundsFinder2D _finder;
    public override void OnInspectorGUI()
    {
        if (_finder == null)
            _finder = target as BoundsFinder2D;

        name = "Bounds Finder 2D";
        

        // ReSharper disable once PossibleNullReferenceException
        _finder.Camera = EditorGUILayout.ObjectField("Camera", _finder.Camera, typeof(Camera), true) as Camera;
        if (_finder.Camera == null)
            return;
        
        GUI.enabled = false;
        EditorGUILayout.Vector2Field("TopLeft", _finder.TopLeft);
        EditorGUILayout.Vector2Field("TopRight", _finder.TopRight);
        EditorGUILayout.Vector2Field("BottomLeft", _finder.BottomLeft);
        EditorGUILayout.Vector2Field("BottomRight", _finder.BottomRight);
        GUI.enabled = true;

        _finder.DrawGizmos = EditorGUILayout.Toggle("Draw Gizmos", _finder.DrawGizmos);

        _finder.ManualUpdate = EditorGUILayout.Toggle("Manual Refresh", _finder.ManualUpdate);
        if (_finder.ManualUpdate)
        {
            if (GUILayout.Button("Refresh"))
                _finder.GetBounds();
        }
        else
        {
            _finder.UpdateDelay = EditorGUILayout.Slider("Update Delay", _finder.UpdateDelay, 0f, 2f);
        }
    }
}
