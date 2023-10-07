using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDataModule", menuName = "Data/Map", order = 1)]
public class MapDataModule : ScriptableObject
{
    public List<MapData> listMap;
    public List<Sprite> listMapMain;
    public List<Sprite> listMapBg;
}
[Serializable]
public struct MapData
{
    public int id;
    public int row;
    public int column;
    public int[] imgBgr;
    public string data;
    public GameObject prefab;
}