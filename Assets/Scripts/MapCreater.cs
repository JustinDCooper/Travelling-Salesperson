using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour
{
    //[HideInInspector]
    public Map map;

    public void CreateMap()
    {
        this.map = new Map(transform.position);
    }

}
