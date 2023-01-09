using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Color debugColour = Color.white;

    [SerializeField]
    private bool alwaysDrawPath;
    [SerializeField]
    private bool drawAsLoop;
    [SerializeField]
    private bool drawNumbers;

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        if (alwaysDrawPath)
            DrawPath();
    }

    public void OnDrawGizmosSelected()
    {
        if (!alwaysDrawPath)
            DrawPath();
    }

    public void DrawPath()
    {
        Gizmos.color = debugColour;
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = 30;
        labelStyle.normal.textColor = debugColour;

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (drawNumbers)
                Handles.Label(waypoints[i].position, i.ToString(), labelStyle);

            if (i >= 1)
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
        }

        if (drawAsLoop && waypoints.Count > 1)
            Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
    }
#endif
}