using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Map
{
    [SerializeField]
    List<Node> nodes;
    uint ID_Tracker=0;
    #region ACCESORS
    public int NodeCount { get { return nodes.Count; } }
    public Node this[int i] { get { return nodes[i]; } }

    #endregion
    public Map(Vector2 first_point)
    {
        nodes = new List<Node> { new Node(ID_Tracker, first_point) };
        ID_Tracker++;
    }

    public void AddNode(Vector2 point)
    {
        Node node= new Node(ID_Tracker,point);
        ID_Tracker++;
        foreach(Node n in nodes)
        {
            node.AddLink(n);
        }
        nodes.Add(node);
    }
}

[System.Serializable]
public class Node
{
    uint id;
    Vector2 pos;
    List<uint> linkIDs;

    #region ACCESSORS
    public Vector2 position { get { return pos; } }
    #endregion
    #region MUTATORS
    public void MoveTo(Vector2 point) { pos = point; }
    #endregion
    public Node(uint ID,Vector2 pos)
    {
        id = ID;
        this.pos = pos;
    }

    public void AddLink(Node node)
    {
        linkIDs.Add(node.id);
    }
}
