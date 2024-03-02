using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(MapCreater))]
public class MapEditor : Editor
{
    MapCreater creator;
    Map map;
    void OnSceneGUI()
    {
        Draw();
    }
    void Input()
    {
        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        if (guiEvent.type == EventType.MouseDown&& guiEvent.button == 0 && guiEvent.shift) 
        {
            Undo.RecordObject(creator, "Add Node");
            map.AddNode(mousePos);
        }
    }
    void Draw()
    {
        Handles.color = Color.white;
        for(int i = 0; i < map.NodeCount; i++)
        {
            Vector2 newPos = Handles.FreeMoveHandle(map[i].position, Quaternion.identity, .1f, Vector2.zero, Handles.CylinderHandleCap);
            if (map[i].position != newPos)
            {
                Undo.RecordObject(creator, "Move node");
                map[i].MoveTo(newPos);
            }
        }
    }

    void OnEnable()
    {
        creator = (MapCreater)target;
        if(creator.map == null)
        {
            creator.CreateMap();
        }
        map = creator.map;
    }

}
